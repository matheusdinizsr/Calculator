

namespace MauiApp1;

public enum EstadoCalculadora
{
    Zerada, 
    PrimeiraEntrada,
    OperacaoEscolhida,
    SegundaEntrada,
    OperacaoRealizada,
    Erro,
}
public partial class MainPage : ContentPage
{
    decimal numeroA = 0;
    decimal numeroB = 0;
    decimal resultado = 0;

    string sinal = "=";
    EstadoCalculadora estado = EstadoCalculadora.Zerada;


    public MainPage()
    {
        InitializeComponent();
    }

    private void OnClick1(object sender, EventArgs e)
    {
        AtribuiEntrada("1");
    }
    private void OnClick7(object sender, EventArgs e)
    {
        AtribuiEntrada("7");
    }
    private void OnClick4(object sender, EventArgs e)
    {
        AtribuiEntrada("4");
    }
    private void OnClick8(object sender, EventArgs e)
    {
        AtribuiEntrada("8");
    }
    private void OnClick5(object sender, EventArgs e)
    {
        AtribuiEntrada("5");
    }
    private void OnClick2(object sender, EventArgs e)
    {
        AtribuiEntrada("2");
    }
    private void OnClick0(object sender, EventArgs e)
    {
        AtribuiEntrada("0");
    }
    private void OnClick9(object sender, EventArgs e)
    {
        AtribuiEntrada("9");
    }
    private void OnClick6(object sender, EventArgs e)
    {
        AtribuiEntrada("6");
    }
    private void OnClick3(object sender, EventArgs e)
    {
        AtribuiEntrada("3");
    }
    private void OnClickSubtracao(object sender, EventArgs e)
    {
        RecebeSinal("-");
    }
    private void OnClickMultiplicacao(object sender, EventArgs e)
    {
        RecebeSinal("*");
    }
    private void OnClickDivisao(object sender, EventArgs e)
    {
        RecebeSinal("/");
    }
    private void OnClickIgual(object sender, EventArgs e)
    {
        RealizaOperacao();
    }
    private void OnClickAdicao(object sender, EventArgs e)
    {
        RecebeSinal("+");
    }
    private void OnClickBack(object sender, EventArgs e)
    {
        TrataErro();
        LabelEntrada.Text = LabelEntrada.Text.Substring(0, LabelEntrada.Text.Length - 1);
        if (LabelEntrada.Text == "")
        {
            LabelEntrada.Text = "0";
        }
    }
    private void OnClickClear(object sender, EventArgs e)
    {
        ResetaCalc();
    }

    private void ResetaCalc()
    {
        estado = EstadoCalculadora.Zerada;
        numeroA = 0;
        numeroB = 0;
        resultado = 0;
        sinal = "=";
        LabelOperacao.Text = "";
        LabelEntrada.Text = "0";

    }

    private void TrataErro()
    {
        if (estado == EstadoCalculadora.Erro)
        {
            ResetaCalc();
        }
    }
    
    private void OnClickClearEntry(object sender, EventArgs e)
    {
        LabelEntrada.Text = "0";
    }
    private void OnClickVirgula(object sender, EventArgs e)
    {
        if (!LabelEntrada.Text.Contains(","))
        {
            LabelEntrada.Text += ",";
        }
    }

    private void TrataFormatacao(string tecla) 
    {
        if (estado != EstadoCalculadora.OperacaoRealizada)
        {
            LabelEntrada.Text += tecla;
        }
        
        decimal milhar = decimal.Parse(LabelEntrada.Text);
        string[] partes = LabelEntrada.Text.Split(',');
        string formato = "N0";

        if (partes.Length > 1) 
        {
            formato = "N" + partes[1].Length;
        }
        
        LabelEntrada.Text = milhar.ToString(formato);
    }
   
    
    public void AtribuiEntrada(string tecla)
    {
        TrataErro();
        TrataFormatacao(tecla);
        
       switch (estado)
       {
            case EstadoCalculadora.Zerada:
            case EstadoCalculadora.OperacaoRealizada:
                estado = EstadoCalculadora.PrimeiraEntrada;
                break;

            case EstadoCalculadora.PrimeiraEntrada:
                break;

            case EstadoCalculadora.OperacaoEscolhida:
                LabelEntrada.Text = tecla;
                estado = EstadoCalculadora.SegundaEntrada;
                break;

            case EstadoCalculadora.SegundaEntrada:
                
                break;
       }
         
    }
    private void RealizaOperacao()
    {
        TrataErro();
        
        switch (estado)
        {
            case EstadoCalculadora.Zerada:
            case EstadoCalculadora.PrimeiraEntrada:
                LabelOperacao.Text = LabelEntrada.Text + " =";
                estado = EstadoCalculadora.OperacaoRealizada;
                break;
            case EstadoCalculadora.OperacaoEscolhida:
                break;
            case EstadoCalculadora.SegundaEntrada:
                numeroB = decimal.Parse(LabelEntrada.Text);
                if (sinal == "+")
                {
                    resultado = numeroA + numeroB;
                }else if (sinal == "-")
                {
                    resultado = numeroA - numeroB;
                }else if (sinal == "/")
                {
                    if (numeroB == 0)
                    {
                        LabelEntrada.Text = "Cannot divide by zero";
                        estado = EstadoCalculadora.Erro;
                        return;
                    }
                    else
                    {
                        resultado = numeroA / numeroB;
                    }
                }else if (sinal == "*")
                {
                    resultado = numeroA * numeroB;
                }
                
                LabelOperacao.Text = numeroA + " " + sinal + " " + numeroB + " =";
                estado = EstadoCalculadora.OperacaoRealizada;
                LabelEntrada.Text = resultado.ToString();
                TrataFormatacao(resultado.ToString());
             
                break;
            case EstadoCalculadora.OperacaoRealizada:
                LabelOperacao.Text = resultado + " " + sinal + " " + numeroB + " =";
               
                if (sinal == "+")
                {
                    resultado += numeroB;
                }else if (sinal == "-")
                {
                    resultado -= numeroB;
                }else if (sinal == "/")
                {
                    resultado /= numeroB;
                }else if (sinal == "*")
                {
                    resultado *= numeroB;
                }

                LabelEntrada.Text = resultado.ToString();
                TrataFormatacao(resultado.ToString());
                break;
        }

       


    }
    private void RecebeSinal(string conta)
    {
        TrataErro();
        switch (estado)
        {
            case EstadoCalculadora.Zerada:
            case EstadoCalculadora.PrimeiraEntrada:
                numeroA = decimal.Parse(LabelEntrada.Text);
                sinal = conta;
                LabelOperacao.Text = numeroA + " " + sinal;
                LabelEntrada.Text = "0";
                estado = EstadoCalculadora.OperacaoEscolhida;
                break;
            case EstadoCalculadora.OperacaoEscolhida:
                sinal = conta;
                LabelOperacao.Text = numeroA + " " + sinal;
                break;
            case EstadoCalculadora.SegundaEntrada:
                RealizaOperacao();
                sinal = conta;
                LabelOperacao.Text = resultado + " " + sinal;
                LabelEntrada.Text = resultado.ToString();
                TrataFormatacao(resultado.ToString());
                numeroA = resultado;
                estado = EstadoCalculadora.OperacaoEscolhida;
                break;
            case EstadoCalculadora.OperacaoRealizada:
                sinal = conta;
                LabelOperacao.Text = resultado.ToString() + " " + sinal;
                numeroA = resultado;
                estado = EstadoCalculadora.OperacaoEscolhida;
                break;
        }
    }

    private void OnClickNegativa(object sender, EventArgs e)
    {
        TrataErro();
        decimal negativa = 0;
        negativa = decimal.Parse(LabelEntrada.Text);
        negativa = negativa * (-1);
        LabelEntrada.Text = negativa.ToString();
    }

}