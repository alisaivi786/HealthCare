global using Microsoft.AspNetCore.Mvc;
global using HealthCare.Application.Contract.IServices;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
global using Common.JWT.Extensions.DependencyInjection.Middleware;
global using Common.JWT;
global using Common.JWT.Interface;
global using HealthCare.Infrastructure.DI.Services;
global using Common.Logging;
global using Serilog;
global using System.Reflection;
global using HealthCare.API.Middleware;