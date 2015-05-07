<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recherche-vol.aspx.cs"  MasterPageFile="template.master" Inherits="recherche_vol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="well bs-component">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Rechercher un vol</legend>
                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Aéroport de départ</label>
                                <div class="col-lg-10">
                                    <select class="form-control">
                                        <option>NTE - Nantes</option>
                                        <option>ORL - Orly</option>
                                    </select>
                                </div>
                        </div>

                        <div class="form-group">
                            <label for="inputEmail" class="col-lg-2 control-label">Aéroport d'arrivée</label>
                                <div class="col-lg-10">
                                    <select class="form-control">
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
                                <button type="submit" class="btn btn-primary">Rechercher</button>
                            </div>
                       </div>
                    </fieldset>
                </form>
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