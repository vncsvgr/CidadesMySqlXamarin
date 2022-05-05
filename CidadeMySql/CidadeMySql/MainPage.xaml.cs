using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CidadeMySql
{
    public partial class MainPage : ContentPage
    {
        Cidade c;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                DisplayAlert("Atenção", "Informe o ID para pesquisa", "OK");
                return;
            }
            c = new Cidade
            {
                id = int.Parse(txtID.Text)
            };
            c.Consultar();
            txtNome.Text = c.nome;
            txtUF.Text = c.uf;
        }

        private void btnLimpar_Clicked(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtUF.Text = string.Empty;
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtUF.Text))
            {
                DisplayAlert("Atenção", "Favor completar as informações do cadastro", "OK");
                return;
            }

            c = new Cidade
            {
                nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Incluir();
            btnLimpar_Clicked(sender, e);
        }

        private async void btnExcluir_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                DisplayAlert("Atenção", "Informar um ID para exclusão", "OK");
                return;
            }

            var resp = await DisplayAlert("Exclusão", "Confirma a exclusão da cidade?", "Sim", "Não");

            if (resp)
            {
                c = new Cidade
                {
                    id = int.Parse(txtID.Text),
                };
                c.Excluir();
                btnLimpar_Clicked(sender, e);
            }
        }

        private void btnFinalizar_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
