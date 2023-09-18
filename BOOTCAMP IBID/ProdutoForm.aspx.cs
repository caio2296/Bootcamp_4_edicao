using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace BOOTCAMP_IBID
{
    public partial class ProdutoFrom : System.Web.UI.Page
    {
       
        string cs = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;

        public void CarregandoDados()
        {
            if (Page.IsPostBack)
            {
                DGridViewProduto.DataBind();
            }
        }

        public void LimparDados()
        {
            txtProdutoId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;   
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            LimparDados();
        }


        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            decimal valor;
            if (txtProdutoId.Text != "")
            {
                if (decimal.TryParse(txtProdutoId.Text, out valor))
                {
                    using (con = new SqlConnection(cs))
                    {
                        con.Open();
                        cmd = new SqlCommand("Delete from Produto where IdProduto = @IdProduto", con);
                        cmd.Parameters.AddWithValue("@IdProduto", txtProdutoId.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        CarregandoDados();
                        LimparDados();
                    }
                }
                else
                {
                    LblMensagem.Text = "O Id precisa ser um numero!";
                }
            }
            else
            {
                LblMensagem.Text = "Precisa informaçar o Id para deletar!";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProdutoId.Text = DGridViewProduto.SelectedRow.Cells[1].Text;
            txtNome.Text = DGridViewProduto.SelectedRow.Cells[2].Text;
            txtPreco.Text = DGridViewProduto.SelectedRow.Cells[3].Text;
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            decimal valor;
            
            if (txtNome.Text!="" && txtPreco.Text!="")
            {
                if (decimal.TryParse(txtPreco.Text, out valor))
                {
                    using (con = new SqlConnection(cs))
                    {
                        con.Open();
                        cmd = new SqlCommand("Insert into Produto (Nome,Preco) values(@nome,@preco)", con);
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@preco", decimal.Parse(txtPreco.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();
                        CarregandoDados();
                        LimparDados();
                    }
                }
                else
                {
                    LblMensagem.Text = "O preço precisa ser um numero!";
                }
               
            }
            else
            {
                LblMensagem.Text = "Precisa informaçar o nome e o preço para adicionar!";
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            decimal valor;

            if (txtNome.Text != "" && txtProdutoId.Text != "")
            {
                if (decimal.TryParse(txtProdutoId.Text, out valor))
                {
                    using (con = new SqlConnection(cs))
                    {
                        con.Open();
                        cmd = new SqlCommand("Update  Produto Set Nome=@nome where IdProduto=@IdProduto", con);
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@IdProduto", int.Parse(txtProdutoId.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();
                        CarregandoDados();
                        LimparDados();
                    }
                }
                else
                {
                    LblMensagem.Text = "O Id precisa ser um numero!";
                }

            }
            else
            {
                LblMensagem.Text = "Precisa informaçar o nome e o preço para adicionar!";
            }
        }
    }
}