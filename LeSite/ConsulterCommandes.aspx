<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsulterCommandes.aspx.cs" MasterPageFile="template.master" Inherits="ConsulterCommandes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="well bs-component">
                <form id="form1" runat="server">
                    <fieldset>
                        <legend>Choix du client</legend>
                        <div class="form-group">
                             <label for="inputEmail" class="col-lg-2 control-label">Nom</label>
                             <div class="col-lg-10">
                                &nbsp;<asp:TextBox ID="nomClient" class="form-control" runat="server"></asp:TextBox>
                             </div>
                        </div>
                        <div class="form-group">
                            <label for="inputPassword" class="col-lg-2 control-label">Prénom</label>
                            <div class="col-lg-10">
                                &nbsp;<asp:TextBox ID="prenomClient" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                                   
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="Consulter" runat="server" class="btn btn-primary" Text="Consulter" OnClick="Consulter_Click" />
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>
    </div>

        <div class="row">

        <% if (vols != null) foreach (var vol in vols){ %>
        <div class="col-md-12">
            <div class="well bs-component">
                <div class="row">
                    <div class="col-md-2 col-sm-3">
                        <img src="img/plane.jpg" alt="dessin d'avion" />
                    </div>
                    <div class="col-md-10 col-sm-9">
        

                        <h3><%=vol.aeroportDepart%> -> <%=vol.aeroportArrive%></h3>
                        <h4>Date de départ : <strong><%=vol.dateDepart%></strong> | Durée : <strong><%=vol.duree%></strong></h4>
                        <h4>Prix : <strong><%=vol.prix%></strong></h4>
                        <p>Compagnie : <strong><%=vol.compagnie%></strong></p>
                       
                    </div>
                </div>
            </div>
        </div>
        <%  }%>

        <% if (hotels != null) foreach (var hotel in hotels)
               { %>
        <div class="col-md-12">
            <div class="well bs-component">
                <div class="row">
                    <div class="col-md-2 col-sm-3  hotel">
                        <span class="glyphicon glyphicon-bed"></span>
                    </div>
                    <div class="col-md-10 col-sm-9">
        
                         <h3> <%=hotel.nomHotel  %> </h3>
                            <h4> <%=hotel.adresse%>,<%=hotel.cp%>,<%=hotel.ville %> </h4>
                            <h4>Téléphone : <strong><%=hotel.tel %> </strong></h4>
                            <br> 
                       
                    </div>
                </div>
            </div>
        </div>
        <%  }%>

    </div>

</asp:Content>