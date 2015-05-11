using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefWSHotel;
using RefWSVol;
using voyage.cmdHotel;
using voyage.cmdVol;

public partial class ValidationCommande : System.Web.UI.Page
{
    public vol vol;
    public Hotel hotel;
    protected void Page_Load(object sender, EventArgs e)
    {
        String idVol = Request["vol"];
        String idHotel = Request["hotel"];

        if (idVol != null)
        {
            //Recuperer le vol selon l'id et l'afficher
        }
        if (idHotel != null)
        {
            //Recuperer l'hotel selon l'id et l'afficher
        }

    }
    protected void btnInscription_Click(object sender, EventArgs e)
    {
        String nom = nomInscription.Text;
        String prenom = prenomInscription.Text;
        String adresse = adresseInscription.Text;
        String cp = cpInscription.Text;
        String ville = villeInscription.Text;
        String tel = telephoneInscription.Text;
        String pays = paysInscription.Text;
        ClsGererCmdHotel myHotel = new ClsGererCmdHotel();
        ClsGererCmdVol myVol = new ClsGererCmdVol();
        myHotel.new_client(nom, prenom, adresse, cp, ville, tel, pays);
        myVol.new_client(nom, prenom, adresse, cp, ville, tel, pays);
    }
    protected void btnConnexion_Click(object sender, EventArgs e)
    {

    }
}