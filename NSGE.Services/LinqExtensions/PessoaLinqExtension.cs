using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos;
using NSGE.Domain.Models;
using System.Linq;
using System.Linq.Expressions;

namespace NSGE.Services.LinqExtensions
{
    public static class PessoaLinqExtension
    {
        public static IQueryable<Pessoa> WhereTipo(this IQueryable<Pessoa> query, params TipoFuncaoPessoaEnum[] tipos)
        {
            if (tipos == null || tipos.Count() == 0)
                return query;

            var x = Expression.Parameter(typeof(Pessoa), "x");

            Expression body = MakeBody(MakeExpressions(x, tipos));

            var lambda = Expression.Lambda<Func<Pessoa, bool>>(body, x);

            return query.Where(lambda);
        }

        
        private static IList<Expression> MakeExpressions(ParameterExpression x, params TipoFuncaoPessoaEnum[] tipos)
        {
            return tipos.Select(tipo =>
                                Expression.Equal(
                                    Expression.PropertyOrField(x, tipo.ToString()),
                                    Expression.Constant(true)))
                            .ToList<Expression>();
        }

        private static Expression MakeBody(IList<Expression> expressions)
        {
            var total = expressions.Count();

            if (total == 1)
                return expressions.First();

            var body = Expression.Or(expressions[0], expressions[1]);

            for (int i = 2; i < total; i++)
            {
                body = Expression.Or(body, expressions[i]);
            }

            return body;
        }

        public static IList<Pessoa> WhereTipo(this IList<Pessoa> query, params TipoFuncaoPessoaEnum[] tipos)
        {
            if (tipos == null || tipos.Count() == 0)
                return query;

            var x = Expression.Parameter(typeof(Pessoa), "x");

            Expression body = MakeBody(MakeExpressions(x, tipos));

            var lambda = Expression.Lambda<Func<Pessoa, bool>>(body, x);

            return query;
        }
    }
}