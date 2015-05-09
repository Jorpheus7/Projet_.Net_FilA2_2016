<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vols.aspx.cs"  MasterPageFile="template.master" Inherits="recherche_vol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="well bs-component">
                <form class="form-horizontal" runat="server">
                    <fieldset>
                        <legend>Rechercher un vol</legend>
                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Aéroport de départ</label>
                                <div class="col-lg-10">
                                    <select id="aeropotDepart" class="form-control">
                                        <option>NTE - Nantes</option>
                                        <option>ORL - Orly</option>
                                    </select>
                                </div>
                        </div>

                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Aéroport d'arrivée</label>
                                <div class="col-lg-10">
                                    <select id="aeroportArrivee" class="form-control">
                                        <option>NTE - Nantes</option>
                                        <option>ORL - Orly</option>
                                    </select>
                                </div>
                        </div>

                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Date de départ</label>
                                <div class="col-lg-10">
                                    <input id="dateDepart" class="form-control">
                                </div>
                        </div>

                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Date de retour</label>
                                <div class="col-lg-10">
                                    <input id="dateRetour" class="form-control">
                                </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-12 col-lg-offset-10">
                                <asp:Button ID="Button1" cssclass="btn btn-primary" runat="server" OnClick="Button1_Click" Text="Rechercher" />
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
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
    </div>

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