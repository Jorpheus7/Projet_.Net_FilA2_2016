<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidationCommande.aspx.cs" MasterPageFile="template.master" Inherits="ValidationCommande" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="well bs-component">
                <div class="row">
                    <div class="col-md-2 col-sm-3">
                        <img src="img/plane.jpg" alt="dessin d'avion" />
                    </div>
                    <div class="col-md-10 col-sm-9">
                        <h3>Nantes -> Orly</h3>
                        <h4>Date de départ : <strong>12 Mai 2015</strong> | Durée : <strong>1h12</strong></h4>
                        <h4>Prix : <strong>58€</strong></h4>
                        <p>Compagnie : <strong>Air France</strong></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
<form class="form-horizontal" runat="server">
    <div class="row">
                    <div class="col-md-6">
                        <div class="well bs-component">
                            
                                <fieldset>
                                    <legend>Je suis déjà client</legend>
                                    <div class="form-group">
                                        <label for="inputEmail" class="col-lg-2 control-label">Nom</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="nomConnexion" cssclass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Prénom</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="prenomConnexion" cssclass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="form-group">
                                        <div class="col-lg-10 col-lg-offset-2">
                                            <asp:Button ID="btnConnexion" cssclass="btn btn-primary" runat="server" Text="Réserver" />
                                        </div>
                                    </div>
                                </fieldset>
                        </div>
                    </div>
                    <div class="col-md-6">

                        <div class="well bs-component">
                                <fieldset>
                                    <legend>Je suis nouveau client</legend>
                                    <div class="form-group">
                                        <label for="inputEmail" class="col-lg-2 control-label">Nom</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="nomInscription" cssclass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Prénom</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="prenomInscription" cssclass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Adresse</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="adresseInscription" cssclass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Code Postal</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="cpInscription" cssclass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Ville</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="villeInscription" cssclass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Téléphone</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="telephoneInscription" cssclass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Pays</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="paysInscription" cssclass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="form-group">
                                        <div class="col-lg-10 col-lg-offset-2">
                                            <asp:Button ID="btnInscription" cssclass="btn btn-primary" runat="server" Text="Réserver" />
                                        </div>
                                    </div>

                                </fieldset>
                            
                        </div>
                        
                    </div>
                </div>
</form>
</asp:Content>