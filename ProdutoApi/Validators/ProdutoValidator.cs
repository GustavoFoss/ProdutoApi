using FluentValidation;
using ProdutoApi.Models;


namespace ProdutoApi.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres.");

            RuleFor(p => p.Preco)
                .GreaterThan(0).WithMessage("Preço deve ser maior que zero.");
        }
    }
}
