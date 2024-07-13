using AnurakStillLife.API.Dtos;
using AnurakStillLife.API.Extensions;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnurakStillLife.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenService tokenService, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await this.userManager.FindByEmailFramClaimsPrincipal(User);
            return new UserDto
            {
                Email = user.Email,
                Token = this.tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await this.userManager.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var user = await this.userManager.FindUserByClaimsPrincipleWithAddress(User);
            return this.mapper.Map<Address, AddressDto>(user.Address);

        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
        {
            var user = await this.userManager.FindUserByClaimsPrincipleWithAddress(HttpContext.User);
            user.Address = this.mapper.Map<AddressDto, Address>(address);

            var result = await this.userManager.UpdateAsync(user);
            if (result.Succeeded) return Ok(this.mapper.Map<Address, AddressDto>(user.Address));

            return BadRequest("Problem updating the user");
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await this.userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            var result = await this.signInManager.CheckPasswordSignInAsync(user, loginDto.Password, true);

            if (!result.Succeeded) return Unauthorized();

            return new UserDto
            {
                Email = user.Email,
                Token = this.tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (CheckEmailExistsAsync(registerDto.Email).Result.Value)
            {
                return new BadRequestObjectResult("Email already exist.");
            }
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.DisplayName
            };

            var result = await this.userManager.CreateAsync(user, registerDto.Password);

            if(!result.Succeeded) return BadRequest();

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = this.tokenService.CreateToken(user),
                Email = user.Email
            };
        }
    }
}
