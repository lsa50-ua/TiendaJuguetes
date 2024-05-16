using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaJuguetes {
    public partial class Site1 : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            try
            {
                if (Session["email"] != null)
                {
                    MainMenu.Items.Remove(MainMenu.FindItem("IniciarSesion"));
                    MainMenu.Items.Add(new MenuItem(Session["email"].ToString()));
                    MainMenu.FindItem(Session["email"].ToString()).Enabled = false;
                    
                
                    ENUsuario en = new ENUsuario();
                    en.EMAIL = Session["email"].ToString();
                    if (en.readUsuarioAdmin() == false)
                    {                      
                        MainMenu.Items.Remove(MainMenu.FindItem("AgregarProducto"));
                    }
                
                }
                else
                {
                
                    MainMenu.Items.Remove(MainMenu.FindItem("CerrarSesion"));
                    MainMenu.Items.Remove(MainMenu.FindItem("AreaPersonal"));
                    MainMenu.Items.Remove(MainMenu.FindItem("AgregarProducto"));
                

                }
            }catch (Exception ex) { };
        }

        protected void MainMenu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
    }
}