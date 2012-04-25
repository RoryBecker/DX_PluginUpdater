<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YesNoAskControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.YesNoAskCombo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'YesNoAskCombo
        '
        Me.YesNoAskCombo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.YesNoAskCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.YesNoAskCombo.FormattingEnabled = True
        Me.YesNoAskCombo.Items.AddRange(New Object() {"Yes", "No", "Ask each time"})
        Me.YesNoAskCombo.Location = New System.Drawing.Point(0, 0)
        Me.YesNoAskCombo.Name = "YesNoAskCombo"
        Me.YesNoAskCombo.Size = New System.Drawing.Size(146, 21)
        Me.YesNoAskCombo.TabIndex = 3
        '
        'YesNoAskControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.YesNoAskCombo)
        Me.Name = "YesNoAskControl"
        Me.Size = New System.Drawing.Size(146, 23)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents YesNoAskCombo As System.Windows.Forms.ComboBox

End Class