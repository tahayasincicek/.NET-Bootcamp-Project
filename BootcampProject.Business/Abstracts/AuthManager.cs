using AutoMapper;
using BootcampProject.Business.Abstracts;
using BootcampProject.Business.DTOs.Requests;
using BootcampProject.Business.DTOs.Responses;
using BootcampProject.Core.Security.Hashing;
using BootcampProject.Core.Security.Jwt;
using BootcampProject.DataAccess.Repositories.Interfaces;
using BootcampProject.Entities;
using System.Threading.Tasks;
using System;

namespace BootcampProject.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;

        public AuthManager(IUserRepository userRepo, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userRepo = userRepo;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepo.GetAsync(u => u.Email == request.Email);
            if (user == null || !HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Email veya şifre hatalı!");

            string role = user switch
            {
                Applicant => "applicant",
                Instructor => "instructor",
                Employee => "employee",
                _ => "user"
            };

            var token = _tokenHelper.CreateToken(user, role);

            return new AuthResponse
            {
                UserId = user.Id,
                Email = user.Email,
                FullName = $"{user.FirstName} {user.LastName}",
                Role = role,
                Token = token
            };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userRepo.GetAsync(u => u.Email == request.Email);
            if (existingUser != null)
                throw new Exception("Bu email zaten kayıtlı!");

            HashingHelper.CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);

            User user = request.Role.ToLower() switch
            {
                "applicant" => new Applicant
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    DateOfBirth = request.DateOfBirth,
                    NationalityIdentity = request.NationalityIdentity,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    About = ""
                },
                "instructor" => new Instructor
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    DateOfBirth = request.DateOfBirth,
                    NationalityIdentity = request.NationalityIdentity,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    CompanyName = ""
                },
                "employee" => new Employee
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    DateOfBirth = request.DateOfBirth,
                    NationalityIdentity = request.NationalityIdentity,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    Position = ""
                },
                _ => throw new Exception("Geçersiz rol.")
            };

            await _userRepo.AddAsync(user);

            string role = request.Role.ToLower();
            var token = _tokenHelper.CreateToken(user, role);

            return new AuthResponse
            {
                UserId = user.Id,
                Email = user.Email,
                FullName = $"{user.FirstName} {user.LastName}",
                Role = role,
                Token = token
            };
        }
    }
}
