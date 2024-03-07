using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poke_ADONET
{
    public partial class Form1 : Form
    {
        private List<Pokemon> listaPokemon;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonDB pokeDB = new PokemonDB();
            listaPokemon = pokeDB.listar();
            dgvPkmns.DataSource = listaPokemon;
            dgvPkmns.Columns["urlImagen"].Visible = false;
            cargarImagen(listaPokemon[0].urlImagen);
        }

        private void dgvPkmns_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPkmns.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.urlImagen);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbImagen.Load(imagen);
            }
            catch (Exception ex)
            {

                pbImagen.Load("https://cdn.dribbble.com/users/5230536/screenshots/15704813/media/bd5494faf77f9c02cd971373627471fe.png?resize=1200x900&vertical=center");
            }
        }
    }
}
