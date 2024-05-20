namespace Common.JWT;
public class JwtTokenAuth(IJwtConfig jwtConfig)
{
    public string GenerateJwtToken(AuthClaim authClaim)
    {
        var claims = new List<Claim>();
        
        #region Get Claims
        foreach (var property in typeof(AuthClaim).GetProperties())
        {
            var value = property.GetValue(authClaim)?.ToString();
            if (!string.IsNullOrEmpty(value))
            {
                claims.Add(new Claim(property.Name, value));
            }
        }
        #endregion

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var expValue = new DateTimeOffset(DateTime.Now.AddMinutes(Convert.ToInt32(jwtConfig.TokenTime))).ToUnixTimeSeconds();

        claims.Add(new(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"));
        claims.Add(new(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"));
        claims.Add(new(JwtRegisteredClaimNames.Exp, $"{expValue}"));
        claims.Add(new(new AuthClaim().Expiration, DateTime.Now.AddMinutes(Convert.ToInt32(jwtConfig.TokenTime)).ToString()));

        var jwt = new JwtSecurityToken(
               issuer: jwtConfig.Issuer,
               audience: jwtConfig.Audience,
               claims: claims,
               signingCredentials: credentials
           );

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.WriteToken(jwt);
        return token;
    }

}
