using AutoMapper;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseTracker.Services;

public class ApplicationUserService : IApplicationUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public ApplicationUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDTO model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            return IdentityResult.Failed(new IdentityError { Description = "Password and Confirm Password do not match" });
        }

        if (string.IsNullOrEmpty(model.Password))
        {
            return IdentityResult.Failed(new IdentityError { Description = "Password cannot be null or empty" });
        }

        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);
        return result;
    }

    public async Task<SignInResult> LoginAsync(LoginDTO model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
        return result;
    }

    public async Task<IEnumerable<ApplicationUserDTO>> GetAllUsersAsync()
    {
        var users = await _userManager.Users
            .ToListAsync();
        return _mapper.Map<IEnumerable<ApplicationUserDTO>>(users);
    }

    public async Task<ApplicationUserDTO> GetUserByIdAsync(string userId)
    {
        var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.Id == userId);
        return _mapper.Map<ApplicationUserDTO>(user);
    }

    public async Task UpdateUserAsync(ApplicationUser user)
    {
        await _userManager.UpdateAsync(user);
    }

    public async Task<bool> DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
        return false;
    }

    public async Task<TokenDTO> GenerateJwtTokenAsync(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var userClaims = await _userManager.GetClaimsAsync(user);
        var premiumClaim = userClaims.FirstOrDefault(c => c.Type == "Subscription" && c.Value == "Premium");
        if (premiumClaim != null)
        {
            claims.Add(new Claim("Subscription", "Premium"));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(token);

        return new TokenDTO
        {
            AccessToken = accessToken,
            Expires = token.ValidTo
        };
    }
}
