<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidationCommande.aspx.cs" MasterPageFile="template.master" Inherits="ValidationCommande" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="well bs-component">
                <div class="row">
                    <% if (vol != null){ %>
                    <div class="col-md-2 col-sm-3">
                        <img src="img/plane.jpg" alt="dessin d'avion" />
                    </div>
                    <div class="col-md-10 col-sm-9">
                        <h3><%=vol.aeroportDepart%> -> <%=vol.aeroportArrive%></h3>
                        <h4>Date de départ : <strong><%=vol.dateDepart%></strong> | Durée : <strong><%=vol.duree%></strong></h4>
                        <h4>Prix : <strong><%=vol.prix%></strong></h4>
                        <p>Compagnie : <strong><%=vol.compagnie%></strong></p>
                        <p> Nombre de personne : <asp:TextBox ID="TextNbPersonneVol" runat="server"></asp:TextBox></p>
                    </div>
                    <%  }%>
                    <% if (hotel != null){ %>
                    <div class="col-md-2 col-sm-3">
                        <span class="glyphicon glyphicon-bed"></span>
                    </div>
                    <div class="col-md-10 col-sm-9">
                        <h3> <%=hotel.nomHotel  %> </h3>
                        <h4> <%=hotel.adresse%>,<%=hotel.cp%>,<%=hotel.ville %> </h4>
                        <h4>Téléphone : <strong><%=hotel.tel %> </strong></h4>
                        <asp:RadioButtonList ID="CheckboxChambres" runat="server"></asp:RadioButtonList>
                        <p> Nombre de personne : <asp:TextBox ID="TextNbPersonneHotel" runat="server"></asp:TextBox></p>

                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Date de départ</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="dateDepart" cssclass="form-control" runat="server"></asp:TextBox>
                                </div>
                        </div>

                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Date de retour</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="dateRetour" cssclass="form-control" runat="server"></asp:TextBox>
                                </div>
                        </div>

                        <br> 
                    </div>
                    <%  }%>
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
                                            <asp:Button ID="btnConnexion" cssclass="btn btn-primary" runat="server" Text="Réserver" OnClick="btnConnexion_Click" />
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
                                            <asp:Button ID="btnInscription" cssclass="btn btn-primary" runat="server" Text="Réserver" OnClick="btnInscription_Click" />
                                        </div>
                                    </div>

                                </fieldset>
                            
                        </div>
                        
                    </div>
                </div>
</form>

<script>
            $(document).ready(function () {
                var options = {
                    format: 'dd/mm/yyyy'
                };
                $('#dateDepart').datepicker(options);
                $('#dateRetour').datepicker(options);
            });
    </script>
</asp:Content>