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

    <div class="row">
                    <div class="col-md-6">
                        <div class="well bs-component">
                            <form class="form-horizontal">
                                <fieldset>
                                    <legend>Je suis déjà client</legend>
                                    <div class="form-group">
                                        <label for="inputEmail" class="col-lg-2 control-label">Nom</label>
                                        <div class="col-lg-10">
                                            <input type="text" class="form-control" id="inputEmail" placeholder="Nom">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Prénom</label>
                                        <div class="col-lg-10">
                                            <input type="text" class="form-control" id="inputPassword" placeholder="prénom" >
                                        </div>
                                    </div>
                                    
                                    <div class="form-group">
                                        <div class="col-lg-10 col-lg-offset-2">
                                            <button type="submit" class="btn btn-primary">Réserver</button>
                                        </div>
                                    </div>
                                </fieldset>
                            </form>
                        </div>
                    </div>
                    <div class="col-md-6">

                        <div class="well bs-component">
                            <form class="form-horizontal">
                                <fieldset>
                                    <legend>Je suis nouveau client</legend>
                                    <div class="form-group">
                                        <label for="inputEmail" class="col-lg-2 control-label">Nom</label>
                                        <div class="col-lg-10">
                                            <input type="text" class="form-control" id="" placeholder="Nom">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Prénom</label>
                                        <div class="col-lg-10">
                                            <input type="text" class="form-control" id="" placeholder="prénom" >
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Adresse</label>
                                        <div class="col-lg-10">
                                            <input type="text" class="form-control" id="" placeholder="adresse" >
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Code Postal</label>
                                        <div class="col-lg-10">
                                            <input type="text" class="form-control" id="" placeholder="code postal" >
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Ville</label>
                                        <div class="col-lg-10">
                                            <input type="text" class="form-control" id="" placeholder="ville" >
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Téléphone</label>
                                        <div class="col-lg-10">
                                            <input type="text" class="form-control" id="" placeholder="téléphone" >
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword" class="col-lg-2 control-label">Pays</label>
                                        <div class="col-lg-10">
                                            <input type="text" class="form-control" id="" placeholder="pays" >
                                        </div>
                                    </div>
                                    
                                    <div class="form-group">
                                        <div class="col-lg-10 col-lg-offset-2">
                                            <button type="submit" class="btn btn-primary">Réserver</button>
                                        </div>
                                    </div>

                                </fieldset>
                            </form>
                        </div>
                        
                    </div>
                </div>

</asp:Content>