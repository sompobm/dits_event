<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Dynamic_Events.Modules.Master.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var RowSelect = function () {
            var data = this.selected.items[0].data;
            Ext.getCmp("FormDetail").setValue(data);
        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceMng" runat="server">
        </ext:ResourceManager>
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:GridPanel ID="grdDetail" runat="server" Title="List" Margins="5 0 5 5"
                    Icon="Group" Region="Center" Frame="true">
                    <Store>
                        <ext:Store ID="storeDetail" runat="server" PageSize="20" RemotePaging="true" RemoteSort="true">
                            <Proxy>
                                <ext:AjaxProxy Url="http://localhost/DynamicEventsAPI/api/Employee/Get">
                                    <Reader>
                                        <ext:JsonReader RootProperty="data" />
                                    </Reader>
                                </ext:AjaxProxy>
                            </Proxy>
                            <Sorters>
                                <ext:DataSorter Property="CompanyNo" />
                            </Sorters>
                            <%--OnReadData="StoreDriver_Refresh">--%>
                            <Model>
                                <ext:Model ID="Model" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="EmpId" />
                                        <ext:ModelField Name="EmpCardNo" />
                                        <ext:ModelField Name="CompanyNo" />
                                        <ext:ModelField Name="EmpName" />
                                        <ext:ModelField Name="CompanyName" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn ID="RowNumbererColumn1" runat="server" Text="No" Width="60" Align="Center" />
                            <ext:Column ID="colEmpCardNo" runat="server" DataIndex="EmpCardNo" Text="Employee No" Flex="1" />
                            <ext:Column ID="colEmpName" runat="server" DataIndex="EmpName" Text="Employee Name" Flex="1" />
                            <ext:Column ID="colCompanyName" runat="server" DataIndex="CompanyName" Text="Company Name" Flex="1" />
                        </Columns>
                    </ColumnModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingTbar" runat="server" DisplayInfo="true" DisplayMsg="Displaying {0} - {1} of {2}"
                            EmptyMsg="No data to display" PrevText="Prev&nbsp;Page" NextText="Next&nbsp;Page"
                            FirstText="First&nbsp;Page" LastText="Last&nbsp;Page" RefreshText="Reload"
                            BeforePageText="<center>Page</center>">
                            <Items>
                                <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                <ext:ToolbarSpacer ID="TbarSpacer" runat="server" Width="10" />
                                <ext:ComboBox ID="cmbPageList" runat="server" Width="80" Editable="false">
                                    <Items>
                                        <ext:ListItem Text="20" />
                                        <ext:ListItem Text="50" />
                                        <ext:ListItem Text="100" />
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Value="20" />
                                    </SelectedItems>
                                    <Listeners>
                                        <Select Handler="#{grdDetail}.store.pageSize = parseInt(this.getValue(), 10);#{grdDetail}.store.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:PagingToolbar>
                    </BottomBar>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" Mode="Single">
                            <Listeners>
                                <Select Fn="RowSelect" />
                            </Listeners>
                        </ext:RowSelectionModel>

                    </SelectionModel>

                </ext:GridPanel>
                <ext:FormPanel Icon="Group" runat="server" ID="FormDetail" Title="Details" Region="East"
                    Margins="5 5 5 5" BodyPadding="2" Frame="true" Width="300" AutoScroll="True" Split="true">
                    <Items>
                        <ext:TextField ID="txtEmpId" runat="server" FieldLabel="Employee Id" Name="EmpId" Hidden="true"/>
                        <ext:TextField ID="txtEmpCardNo" runat="server" FieldLabel="Employee No" Name="EmpCardNo" />
                        <ext:TextField ID="txtEmpName" runat="server" FieldLabel="Employee Name" Name="EmpName" AllowBlank="false" />
                        <ext:TextField ID="txtCompanyNo" runat="server" FieldLabel="Company No" Name="CompanyNo" Width="200"/>
                        <ext:TextField ID="txtCompanyName" runat="server" FieldLabel="Company Name" Name="CompanyName" />
                    </Items>
                    <BottomBar>
                        <ext:Toolbar runat="server" ID="toolbarControls">
                            <Items>
                                <ext:ToolbarFill ID="TbarFill" runat="server" />
                                <ext:Button ID="btnSave" runat="server" Icon="Disk" Text="Save" Disabled="true">
                                    <%--<DirectEvents>
                                        <Click OnEvent="btnSave_Click" />
                                    </DirectEvents>--%>
                                </ext:Button>
                                <ext:Button ID="btnClear" runat="server" Icon="PageWhite" Text="Clear">
                                    <%--   <DirectEvents>
                                        <Click OnEvent="btnClear_Click" />
                                    </DirectEvents>--%>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </BottomBar>
                    <Listeners>
                        <ValidityChange Handler="#{btnSave}.setDisabled(!valid); " />
                    </Listeners>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
