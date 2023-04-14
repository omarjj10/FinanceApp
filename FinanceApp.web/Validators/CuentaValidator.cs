using FinanceApp.web.Models;

namespace FinanceApp.web.Validators;

public class CuentaValidator
{
    public bool hasUniqueName(DbEntities entities, Cuenta cuenta)
    {
        return entities.Cuentas.Count(o => o.Nombre == cuenta.Nombre)==0;
    }
}