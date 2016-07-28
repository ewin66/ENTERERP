;#DropDB EnterERPEasyTest

#Application EnterERP.Win
#Application EnterERP.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef EnterERP.Win

*Action About...
 
*Action OK

#EndIf

#IfDef EnterERP.Web
*Action Navigation(My Details)
#EndIf
