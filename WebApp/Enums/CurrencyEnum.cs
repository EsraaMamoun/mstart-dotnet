using System.ComponentModel.DataAnnotations;

namespace WebApp.Enums
{
    public class CurrencyEnum
    {
    }
}

public enum CurrencyEnum
{
    [Display(Name = "Jordanian Dinar (JOD)")]
    JOD,

    [Display(Name = "Egyptian Pound (EGP)")]
    EGP,

    [Display(Name = "Kuwaiti Dinar (KWD)")]
    KWD,

    [Display(Name = "United States Dollar (USD)")]
    USD
}