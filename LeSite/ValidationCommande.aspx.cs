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
    public Boolean resaVol;
    public Boolean resaHotel;

    protected void Page_Load(object sender, EventArgs e)
    {
        resaHotel = false;
        resaVol = false;
        String idVol = Request["vol"];
        String idHotel = Request["hotel"];

        if (idVol != null)
        {
            resaVol = true;
            WSVol myWSVol = new WSVol();
            vol = myWSVol.vol_id(int.Parse(idVol));
        }
        if (idHotel != null)
        {
            resaHotel = true;
            WSHotel myWSHotel = new WSHotel();
            hotel = myWSHotel.hotel_id(int.Parse(idHotel));
            Chambre[] chambres = myWSHotel.liste_chambres_hotels(idHotel);

            foreach (var chambre in chambres)
            {
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

        if (resaVol)
        {
            if (TextNbPersonneVol.Text == "")
            {
                LabelResaCreation.Text = "Veuillez renseigner le nombre de personnes";
            }
            else
            {
                int nbPersonne = int.Parse(TextNbPersonneVol.Text);
                myVol.new_cmdvol_existing_client(vol.id, clientVol.id, DateTime.Now.ToString("dd/MM/yyyy"), nbPersonne, vol.prix * Convert.ToInt16(nbPersonne));
                LabelResaCreation.Text = "La commande à bien été enregistré";
            }
        }
        if (TextNbPersonneHotel.Text == "")
        {
            LabelResaCreation.Text = "Veuillez renseigner le nombre de personnes";
        }
        else
        {
            WSHotel myWSHotel = new WSHotel();
            Chambre[] chambres = myWSHotel.liste_chambres_hotels(hotel.id.ToString());
            Chambre chambre = null;
            foreach (var c in chambres)
            {
                if (c.id == int.Parse(CheckboxChambres.SelectedItem.Value))
                {
                    chambre = c;
                }
            }

            int nbPersonne = int.Parse(TextNbPersonneHotel.Text);
            myHotel.new_cmdhotel_existing_client(chambre.id, clientVol.id, DateTime.Now.ToString("dd/MM/yyyy"), nbPersonne, chambre.prix,
                dateDepart.Text, dateRetour.Text);
            LabelResaCreation.Text = "La commande à bien été enregistré";
        }
    }


    protected void btnConnexion_Click(object sender, EventArgs e)
    {
      
            string nom = nomConnexion.Text;
            string prenom = prenomConnexion.Text;
            if (nom != "" && prenom != "")
            {
                int nbPersonne = int.Parse(TextNbPersonneVol.Text);

                if (resaVol)
                {
                    if (TextNbPersonneVol.Text == "")
                    {
                        LabelResaConnexion.Text = "Veuillez renseigner le nombre de personnes";
                    }
                    else
                    {
                        voyage.cmdVol.Client cVol;
                        ClsGererCmdVol myClsCmdVol = new ClsGererCmdVol();
                        cVol = myClsCmdVol.client_nom_prenom(nom, prenom);
                        if (cVol != null)
                        {
                            myClsCmdVol.new_cmdvol_existing_client(vol.id, cVol.id, DateTime.Now.ToString("dd/MM/yyyy"), nbPersonne, vol.prix * Convert.ToInt16(nbPersonne));
                            LabelResaConnexion.Text = "La commande à bien été enregistré";
                        }
                        else
                        {
                            LabelResaConnexion.Text = "Ce client n'existe pas, veuillez remplir le formulaire de gauche.";
                        }
                    }
                }
                if (resaHotel)
                {
                    if (TextNbPersonneHotel.Text == "")
                    {
                        LabelResaCreation.Text = "Veuillez renseigner le nombre de personnes";
                    }
                    else
                    {
                        int nbPersonneHotel = int.Parse(TextNbPersonneHotel.Text);
                        WSHotel myWSHotel = new WSHotel();
                        Chambre[] chambres = myWSHotel.liste_chambres_hotels(hotel.id.ToString());
                        Chambre chambre = null;
                        foreach (var c in chambres)
                        {
                            if (c.id == int.Parse(CheckboxChambres.SelectedItem.Value))
                            {
                                chambre = c;
                            }
                        }
                        ClsGererCmdHotel myHotel = new ClsGererCmdHotel();
                        voyage.cmdHotel.Client cHotel;
                        cHotel = myHotel.client_nom_prenom(nom, prenom);
                        if (cHotel != null)
                        {
                            myHotel.new_cmdhotel_existing_client(chambre.id, cHotel.id, DateTime.Now.ToString("dd/MM/yyyy"), nbPersonneHotel, chambre.prix,
                             dateDepart.Text, dateRetour.Text);
                            LabelResaConnexion.Text = "La commande à bien été enregistré";
                        }
                        else
                        {
                            LabelResaConnexion.Text = "Ce client n'existe pas, veuillez remplir le formulaire de gauche.";
                        }
                        
                    }
                }
            }      
    }
}