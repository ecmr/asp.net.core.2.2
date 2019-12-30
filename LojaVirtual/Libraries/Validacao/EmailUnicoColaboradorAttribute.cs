using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Libraries.Validacao
{
    public class EmailUnicoColaboradorAttribute: ValidationAttribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = (value as string).Trim();
            IColaboradorRepository _colaboradorRepository = (IColaboradorRepository)validationContext.GetService(typeof(IColaboradorRepository));

            List<Colaborador> colaboradores = _colaboradorRepository.ObterColaboradorPorEmail(email);

            Colaborador objColaborador = (Colaborador)validationContext.ObjectInstance;

            if (colaboradores.Count > 1)
            {
                return new ValidationResult("E-mail já cadastrado");
            }
            if (colaboradores.Count == 1 && objColaborador.id != colaboradores[0].id)
            {
                return new ValidationResult("E-mail já cadastrado");
            }

            return ValidationResult.Success;
        }
    }
}
