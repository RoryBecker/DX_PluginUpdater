<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PluginPicker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstPlugins = New System.Windows.Forms.ListView()
        Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdSelectAll = New System.Windows.Forms.Button()
        Me.cmdSelectNone = New System.Windows.Forms.Button()
        Me.lnkWiki = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lnkSource = New System.Windows.Forms.LinkLabel()
        Me.lnkBinaries = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstPlugins
        '
        Me.lstPlugins.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstPlugins.CheckBoxes = True
        Me.lstPlugins.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName})
        Me.lstPlugins.Location = New System.Drawing.Point(12, 12)
        Me.lstPlugins.Name = "lstPlugins"
        Me.lstPlugins.Size = New System.Drawing.Size(411, 257)
        Me.lstPlugins.TabIndex = 1
        Me.lstPlugins.UseCompatibleStateImageBehavior = False
        Me.lstPlugins.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        Me.colName.Text = "Name"
        Me.colName.Width = 300
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(343, 360)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Location = New System.Drawing.Point(262, 360)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 3
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(22, 360)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelectAll.TabIndex = 4
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdSelectNone
        '
        Me.cmdSelectNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectNone.Location = New System.Drawing.Point(103, 360)
        Me.cmdSelectNone.Name = "cmdSelectNone"
        Me.cmdSelectNone.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelectNone.TabIndex = 5
        Me.cmdSelectNone.Text = "Select None"
        Me.cmdSelectNone.UseVisualStyleBackColor = True
        '
        'lnkWiki
        '
        Me.lnkWiki.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkWiki.AutoSize = True
        Me.lnkWiki.Location = New System.Drawing.Point(7, 16)
        Me.lnkWiki.Name = "lnkWiki"
        Me.lnkWiki.Size = New System.Drawing.Size(56, 13)
        Me.lnkWiki.TabIndex = 7
        Me.lnkWiki.TabStop = True
        Me.lnkWiki.Text = "Wiki Page"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lnkSource)
        Me.GroupBox1.Controls.Add(Me.lnkBinaries)
        Me.GroupBox1.Controls.Add(Me.lnkWiki)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 275)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 79)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Details"
        '
        'lnkSource
        '
        Me.lnkSource.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkSource.AutoSize = True
        Me.lnkSource.Location = New System.Drawing.Point(7, 42)
        Me.lnkSource.Name = "lnkSource"
        Me.lnkSource.Size = New System.Drawing.Size(41, 13)
        Me.lnkSource.TabIndex = 9
        Me.lnkSource.TabStop = True
        Me.lnkSource.Text = "Source"
        '
        'lnkBinaries
        '
        Me.lnkBinaries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkBinaries.AutoSize = True
        Me.lnkBinaries.Location = New System.Drawing.Point(7, 29)
        Me.lnkBinaries.Name = "lnkBinaries"
        Me.lnkBinaries.Size = New System.Drawing.Size(44, 13)
        Me.lnkBinaries.TabIndex = 8
        Me.lnkBinaries.TabStop = True
        Me.lnkBinaries.Text = "Binaries"
        '
        'PluginPicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 395)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdSelectNone)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lstPlugins)
        Me.Name = "PluginPicker"
        Me.Text = "PluginPicker"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstPlugins As System.Windows.Forms.ListView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectNone As System.Windows.Forms.Button
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents lnkWiki As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lnkSource As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkBinaries As System.Windows.Forms.LinkLabel
End Class
