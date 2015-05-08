<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsulterCommandes.aspx.cs" MasterPageFile="template.master" Inherits="ConsulterCommandes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="well bs-component">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Choix du client</legend>
                        <div class="form-group">
                             <label for="inputEmail" class="col-lg-2 control-label">Nom</label>
                             <div class="col-lg-10">
                                <input type="text" class="form-control" id="nomClient" placeholder="Nom">
                             </div>
                        </div>
                        <div class="form-group">
                            <label for="inputPassword" class="col-lg-2 control-label">Prénom</label>
                            <div class="col-lg-10">
                                <input type="text" class="form-control" id="prenomClient" placeholder="prénom" >
                            </div>
                        </div>
                                   
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <button type="submit" class="btn btn-primary">Consulter</button>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>
    </div>

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

        <div class="col-md-12">
            <div class="well bs-component">
                <div class="row">
                    <div class="col-md-2 col-sm-3 hotel">
                        <span class="glyphicon glyphicon-bed"></span>
                    </div>
                    <div class="col-md-10 col-sm-9">
                        <h3>Orly</h3>
                        <h4>Du <strong>12 Mai 2015</strong> au <strong>16 Mai 2015</strong></h4>
                        <h4>Prix : <strong>260€</strong></h4>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>