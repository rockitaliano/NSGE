using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSGE.CrosCutting.Enum
{
    public enum TipoDocumento
    {
        [EnumDescription("receber")]
        [EnumText("Boleto")]
        [EnumValue("0")]
        Boleto = 0,

        [EnumDescription("pagar")]
        [EnumText("Cheque")]
        [EnumValue("1")]
        Cheque = 1,

        [EnumDescription("")]
        [EnumText("Dinheiro")]
        [EnumValue("2")]
        Dinheiro = 2,

        [EnumDescription("")]
        [EnumText("Depósito")]
        [EnumValue("3")]
        Deposito = 3,

        [EnumDescription("")]
        [EnumText("Cartão")]
        [EnumValue("4")]
        Cartao = 4,

        [EnumDescription("")]
        [EnumText("Duplicata")]
        [EnumValue("5")]
        Duplicata = 5,

        [EnumDescription("")]
        [EnumText("NF")]
        [EnumValue("6")]
        NF = 6,

        [EnumDescription("")]
        [EnumText("NP")]
        [EnumValue("7")]
        NP = 7,

        [EnumDescription("pagar")]
        [EnumText("Internet")]
        [EnumValue("8")]
        Internet = 8,

        [EnumDescription("receber/pagar")]
        [EnumText("Crédito em conta corrente")]
        [EnumValue("9")]
        CreditoContaCorrente = 9,

        [EnumDescription("pagar")]
        [EnumText("Caixa")]
        [EnumValue("10")]
        Caixa = 10,

        [EnumDescription("pagar")]
        [EnumText("Débito")]
        [EnumValue("11")]
        Debito = 11,
    }
}
