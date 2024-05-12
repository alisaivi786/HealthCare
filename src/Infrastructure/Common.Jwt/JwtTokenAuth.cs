namespace Common.Jwt;
public static class JwtTokenAuth
{
    public static string GenerateJwtToken(AuthClaim authClaim, string Secretbase64Key = "Wwp7CiJBdXRob3IiOiBBTEksCiJBcHAiOiAiSGVhbHRoQ2FyZSIsCiJUeXBlIjoiQXBpIiwKIkVtYWlsIjoiYWxpc2Fpdmk3ODZAZ21haWwuY29tIiwKIlNlY3JldGVLZXkiOiJhc2RmZ2hqa2wwOTg3NjU0MzIxIgp9Cl0=")
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

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Secretbase64Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(20),
            Issuer = authClaim.Issuer,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

}
