<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zone.aspx.cs" Inherits="Dynamic_Events.Modules.Master.Zone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceMng" runat="server">
        </ext:ResourceManager>
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:GridPanel ID="GridPanelDriver" runat="server" Title="Driver List" Margins="5 0 5 5"
                    Icon="Group" Region="Center" Frame="true">
                    <Store>
                        <ext:Store ID="StoreDriver" runat="server" PageSize="20">
                            <%--OnReadData="StoreDriver_Refresh">--%>
                            <Model>
                                <ext:Model ID="Model" runat="server" IDProperty="DriverId">
                                    <Fields>
                                        <ext:ModelField Name="DriverId" />
                                        <ext:ModelField Name="TrailerCompanyId" />
                                        <ext:ModelField Name="Name" />
                                        <ext:ModelField Name="DriverCode" />
                                        <ext:ModelField Name="DriverFName" />
                                        <ext:ModelField Name="DriverLName" />
                                        <ext:ModelField Name="DriverLicence" />
                                        <ext:ModelField Name="DriverType" />
                                        <ext:ModelField Name="EffectiveDate" Type="Date" />
                                        <ext:ModelField Name="ExpireDate" Type="Date" />
                                        <ext:ModelField Name="IsActive" Type="Boolean" />
                                        <ext:ModelField Name="IsNew" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModelDriver" runat="server">
                        <Columns>
                            <ext:Column ID="Column1" runat="server" DataIndex="DriverId" Text="Driver ID" Width="50" />
                            <ext:Column ID="ColumnTrailerCompany" runat="server" DataIndex="Name" Text="Trailer Company" Flex="1" />
                            <ext:Column ID="ColumnDriverCode" runat="server" DataIndex="DriverCode" Text="Driver Code" Flex="1" />
                            <ext:Column ID="ColumnDriverFName" runat="server" DataIndex="DriverFName" Text="First Name" Flex="1" />
                            <ext:Column ID="ColumnDriverLName" runat="server" DataIndex="DriverLName" Text="Last Name" Flex="1" />
                            <ext:Column ID="ColumnDriverLicence" runat="server" DataIndex="DriverLicence" Text="Driver Licence" Flex="1" />
                            <ext:Column ID="ColumnDriverType" runat="server" DataIndex="DriverType" Text="Driver Type" Flex="1" />
                            <ext:DateColumn ID="DateColEffect" runat="server" DataIndex="EffectiveDate" Text="Effective Date" Flex="1" />
                            <ext:DateColumn ID="DateColExpire" runat="server" DataIndex="ExpireDate" Text="Expire Date" Flex="1" />
                            <ext:CheckColumn ID="ColumnIsActive" runat="server" DataIndex="IsActive" Text="Active" Width="50" />
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
                                        <Select Handler="#{GridPanelDriver}.store.pageSize = parseInt(this.getValue(), 10);
                                         #{GridPanelDriver}.store.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:PagingToolbar>
                    </BottomBar>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectModel" runat="server" Mode="Single">
                            <%-- <DirectEvents>
                                <Select OnEvent="RowModel_Select">
                                    <EventMask CustomTarget="FormPanelDriver" ShowMask="true" Target="CustomTarget" />
                                    <ExtraParams>
                                        <ext:Parameter Name="DriverId" Value="record.getId()" Mode="Raw" />
                                    </ExtraParams>
                                </Select>
                            </DirectEvents>--%>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                </ext:GridPanel>
                <ext:FormPanel Icon="Group" runat="server" ID="FormPanelDriver" Title="Driver Details" Region="East"
                    Margins="5 5 5 5" BodyPadding="2" Frame="true" Width="300" AutoScroll="True" Split="true">
                    <Items>
                        <ext:TextField ID="txtDriverId" runat="server" FieldLabel="Driver ID" Name="DriverId" Text="0" Disabled="true" />
                        <ext:ComboBox ID="cmbCompany" runat="server" FieldLabel="Company" DisplayField="Name" ValueField="TrailerCompanyId" Editable="false" AllowBlank="false">
                            <Store>
                                <ext:Store ID="StoreTrailerCompany" runat="server">
                                    <Model>
                                        <ext:Model ID="ModelTrailerCompany" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="TrailerCompanyId" />
                                                <ext:ModelField Name="Name" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:TextField ID="txtDriverCode" runat="server" FieldLabel="Driver Code" Name="DriverCode" Width="200" AllowBlank="false" />
                        <ext:TextField ID="txtFName" runat="server" FieldLabel="First Name" Name="DriverFName" AllowBlank="false" />
                        <ext:TextField ID="txtLName" runat="server" FieldLabel="Last Name" Name="DriverLName" />
                        <ext:TextField ID="txtDriverLicence" runat="server" FieldLabel="Driver Licence" Name="DriverLicence" />
                        <ext:TextField ID="txtDriverType" runat="server" FieldLabel="Driver Type" Name="DriverType" Width="150" />

                        <ext:DateField runat="server" ID="dateEffectiveDate"
                            Vtype="daterange"
                            Name="EffectiveDate"
                            FieldLabel="Effective Date"
                            Format="yyyy/MM/dd"
                            EnableKeyEvents="true"
                            Width="200">
                            <CustomConfig>
                                <ext:ConfigItem Name="endDateField" Value="dateExpireDate" Mode="Value" />
                            </CustomConfig>
                        </ext:DateField>

                        <ext:DateField runat="server" ID="dateExpireDate"
                            Vtype="daterange"
                            Name="ExpireDate"
                            FieldLabel="Expire Date"
                            Format="yyyy/MM/dd"
                            EnableKeyEvents="true"
                            Width="200">
                            <CustomConfig>
                                <ext:ConfigItem Name="startDateField" Value="dateEffectiveDate" Mode="Value" />
                            </CustomConfig>
                        </ext:DateField>


                        <ext:Checkbox ID="chkIsActive" runat="server" FieldLabel="Active" Name="IsActive" Checked="true" />
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
