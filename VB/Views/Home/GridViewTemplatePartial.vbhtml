@ModelType List(Of VB.Person)
@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "grid"
            settings.KeyFieldName = "PersonID"
            settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewTemplatePartial"}

            settings.SettingsEditing.Mode = GridViewEditingMode.Inline
            settings.SettingsEditing.AddNewRowRouteValues = New With {Key .Controller = "Home", Key .Action = "EditingAddNew"}
            settings.SettingsEditing.UpdateRowRouteValues = New With {Key .Controller = "Home", Key .Action = "EditingUpdate"}
            settings.SettingsEditing.DeleteRowRouteValues = New With {Key .Controller = "Home", Key .Action = "EditingDelete"}

            'Command Column Emulation
            settings.Columns.Add( _
                Sub(column)
                        column.Caption = "#"
            
                        'DataItemTemplate
                        'New - Edit - Delete Buttons
                        column.SetDataItemTemplateContent( _
                            Sub(c)
                                    Html.DevExpress().HyperLink( _
                                        Sub(hl)
                                                hl.Name = "hlNew_" + c.KeyValue.ToString()
                                                hl.NavigateUrl = "javascript:;"
                                                hl.Properties.Text = "New"
                                                hl.Properties.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.AddNewRow(); }}", settings.Name)
                                        End Sub).Render()

                                    ViewContext.Writer.Write("&nbsp;")

                                    Html.DevExpress().HyperLink( _
                                        Sub(hl)
                                                hl.Name = "hlEdit_" + c.KeyValue.ToString()
                                                hl.NavigateUrl = "javascript:;"
                                                hl.Properties.Text = "Edit"
                                                hl.Properties.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.StartEditRow('{1}'); }}", settings.Name, c.VisibleIndex)
                                        End Sub).Render()

                                    ViewContext.Writer.Write("&nbsp;")

                                    Html.DevExpress().HyperLink( _
                                        Sub(hl)
                                                hl.Name = "hlDelete_" + c.KeyValue.ToString()
                                                hl.NavigateUrl = "javascript:;"
                                                hl.Properties.Text = "Delete"
                                                hl.Properties.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.DeleteRow('{1}'); }}", settings.Name, c.VisibleIndex)
                                        End Sub).Render()
                
                            End Sub)
                        'DataItemTemplate

                        'EditItemTemplate
                        'Update Button Only - No Cancel Button
                        column.SetEditItemTemplateContent( _
                            Sub(c)
                                    ViewContext.Writer.Write("<div style=""text-align: right;"">")
                
                                    Html.DevExpress().HyperLink( _
                                        Sub(hl)
                                                hl.Name = "hlUpdate"
                                                hl.NavigateUrl = "javascript:;"
                    
                                                hl.Properties.Text = If(c.Grid.IsNewRowEditing, "Add", "Update")
                    
                                                hl.Properties.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.UpdateEdit(); }}", settings.Name)
                                        End Sub).Render()

                                    ViewContext.Writer.Write("</div>")
                            End Sub)
                        'EditItemTemplate
            
                End Sub)
            'Command Column Emulation

            settings.Columns.Add("FirstName")
            settings.Columns.Add("MiddleName")
            settings.Columns.Add("LastName")
    End Sub).Bind(Model).GetHtml()