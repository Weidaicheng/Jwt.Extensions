using JWT.Extensions.Attributes;
using JWT.Extensions.DependencyInjection.Options;
using JWT.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq;

namespace JWT.Extensions.Mvc
{
    /// <summary>
    /// abstract jwt controller which is inherited from <see cref="Controller"/>,
    /// it overrides the <see cref="Controller.OnActionExecuting(ActionExecutingContext)"/> method to verify jwt token.
    /// </summary>
    public abstract class JwtControllerBase : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //resolve
            var jwtDecoder = HttpContext.RequestServices.GetRequiredService<IJwtDecoder>();
            var jwtOptions = HttpContext.RequestServices.GetRequiredService<IOptions<JwtOptions>>().Value;

            //options check
            if (string.IsNullOrEmpty(jwtOptions.SecretStr) && (jwtOptions.SecretBytes == null || jwtOptions.SecretBytes.Length == 0))
                throw new NoSecretSpecifiedException();

            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var controllerTypeInfo = actionDescriptor.ControllerTypeInfo;
            var methodInfo = actionDescriptor.MethodInfo;
            var jwtCheckOnController = controllerTypeInfo.GetCustomAttributes(typeof(JwtCheckAttribute), false);
            var jwtCheckOnAction = actionDescriptor.MethodInfo.GetCustomAttributes(typeof(JwtCheckAttribute), false);

            if (jwtCheckOnController.Length == 0 && jwtCheckOnAction.Length == 0)
            {
                //without jwtcheck
                base.OnActionExecuting(context);
            }
            else if (jwtCheckOnController.Length > 0 && jwtCheckOnAction.Length == 0)
            {
                //check ignore on controller
                var jwtCheckAttr = jwtCheckOnController.First() as JwtCheckAttribute;
                if (jwtCheckAttr.Ignore)
                {
                    //without jwtcheck
                    base.OnActionExecuting(context);
                }
                else
                {
                    //with jwtcheck
                    var token = TokenGainerFactory.GetTokenGainer(jwtOptions.Bearer).GainToken(context.HttpContext.Request, jwtOptions.TokenBearerKey);
                    if(TokenVerifierFactory.GetTokenVerifier(jwtOptions).VerifyToken(jwtDecoder, token, jwtOptions))
                    {
                        //token verify success
                        base.OnActionExecuting(context);
                    }
                    else
                    {
                        //token verify fail
                        context.HttpContext.Response.Redirect(jwtOptions.RedirectUrl);
                    }
                }
            }
            else if (jwtCheckOnController.Length > 0 && jwtCheckOnAction.Length > 0)
            {
                //check ignore on controller
                var jwtCheckAttr = jwtCheckOnController.First() as JwtCheckAttribute;
                if (jwtCheckAttr.Ignore)
                {
                    //without jwtcheck
                    base.OnActionExecuting(context);
                }
                else
                {
                    //check ignore on action
                    jwtCheckAttr = jwtCheckOnAction.First() as JwtCheckAttribute;
                    if (jwtCheckAttr.Ignore)
                    {
                        //without jwtcheck
                        base.OnActionExecuting(context);
                    }
                    else
                    {
                        //with jwtcheck
                        var token = TokenGainerFactory.GetTokenGainer(jwtOptions.Bearer).GainToken(context.HttpContext.Request, jwtOptions.TokenBearerKey);
                        if (TokenVerifierFactory.GetTokenVerifier(jwtOptions).VerifyToken(jwtDecoder, token, jwtOptions))
                        {
                            //token verify success
                            base.OnActionExecuting(context);
                        }
                        else
                        {
                            //token verify fail
                            context.HttpContext.Response.Redirect(jwtOptions.RedirectUrl);
                        }
                    }
                }
            }
            else
            {
                //check ignore on action
                var jwtCheckAttr = jwtCheckOnAction.First() as JwtCheckAttribute;
                if (jwtCheckAttr.Ignore)
                {
                    //without jwtcheck
                    base.OnActionExecuting(context);
                }
                else
                {
                    //with jwtcheck
                    var token = TokenGainerFactory.GetTokenGainer(jwtOptions.Bearer).GainToken(context.HttpContext.Request, jwtOptions.TokenBearerKey);
                    if (TokenVerifierFactory.GetTokenVerifier(jwtOptions).VerifyToken(jwtDecoder, token, jwtOptions))
                    {
                        //token verify success
                        base.OnActionExecuting(context);
                    }
                    else
                    {
                        //token verify fail
                        context.HttpContext.Response.Redirect(jwtOptions.RedirectUrl);
                    }
                }
            }
        }
    }
}
