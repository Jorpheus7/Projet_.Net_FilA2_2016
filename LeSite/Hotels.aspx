<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hotels.aspx.cs" MasterPageFile="template.master" Inherits="Hotels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="well bs-component">
                <form class="form-horizontal" runat="server">
                    <fieldset>
                        <legend>Rechercher un hotel</legend>
                        <div class="form-group">
                           
                                <div class="col-lg-10">
                                     Ville : <asp:DropDownList ID="villeListe" cssclass="form-control" runat="server"></asp:DropDownList>
                                </div>
                        </div>

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

                        <div class="form-group">
                            <div class="col-md-12 col-lg-offset-10">
                                <asp:Button ID="Button1" cssclass="btn btn-primary" runat="server" OnClick="Button1_Click" Text="Rechercher" />
                            </div>
                       </div>
                    </fieldset>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="well bs-component">
                <div class="row">
                    <div class="col-md-2 col-sm-3 hotel">
                        <span class="glyphicon glyphicon-bed"></span>
                    </div>
                    <div class="col-md-10 col-sm-9">
                         <% if(hotels != null) foreach (var hotel in hotels) {  %> 
                            <h3> <%=hotel.nomHotel  %> </h3>
                            <h4> <%=hotel.adresse%>,<%=hotel.cp%>,<%=hotel.ville %> </h4>
                            <h4>Téléphone : <strong><%=hotel.tel %> </strong></h4>
                            <a href="ValidationCommande.aspx?hotel=<%=hotel.id%>" class="btn  btn-primary">Reserver</a>
                            <br> 
                             <% } %>
                    </div>
                </div>
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