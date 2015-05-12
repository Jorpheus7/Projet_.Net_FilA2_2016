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
            WSVol myWSVol = new WSVol();
            vol = myWSVol.vol_id(int.Parse(idVol));
        }
        if (idHotel != null)
        {
            WSHotel myWSHotel = new WSHotel();
            hotel = myWSHotel.hotel_id(int.Parse(idHotel));
            Chambre[] chambres = myWSHotel.liste_chambres_hotels(idHotel);

            foreach (var chambre in chambres) {
                ListItem item = new ListItem();
                item.Value = chambre.id.ToString();
                item.Text = "Chambre N°" + chambre.numero + " au prix de : " + chambre.prix + "€";
                CheckboxChambres.Items.Add(item);
            }

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
        voyage.cmdHotel.Client clientHotel = myHotel.new_client(nom, prenom, adresse, cp, ville, tel, pays);
        voyage.cmdVol.Client clientVol = myVol.new_client(nom, prenom, adresse, cp, ville, tel, pays);

        if (this.vol != null)
        {
            int nbPersonne = int.Parse(TextNbPersonneVol.Text);
            myVol.new_cmdvol_existing_client(vol.id, clientVol.id, DateTime.Now.ToString("dd/MM/yyyy"), nbPersonne, vol.prix);
        }
        if (this.hotel != null)
        {
            WSHotel myWSHotel = new WSHotel();
            Chambre[] chambres = myWSHotel.liste_chambres_hotels(hotel.id.ToString());
            Chambre chambre = null;
            foreach (var c in chambres){
                if(c.id == int.Parse(CheckboxChambres.SelectedItem.Value)){
                    chambre = c;
                }
            }

            int nbPersonne = int.Parse(TextNbPersonneHotel.Text);
            myHotel.new_cmdhotel_existing_client(chambre.id, clientVol.id, DateTime.Now.ToString("dd/MM/yyyy"), nbPersonne, chambre.prix,
                dateDepart.Text, dateRetour.Text);
        }
    }
    protected void btnConnexion_Click(object sender, EventArgs e)
    {

    }
}