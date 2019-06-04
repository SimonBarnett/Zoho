'Imports Teference.Zoho.Api

'Public Class send

'    Public zohoClient As IZohoClient

'    Public Sub New()
'        Dim conf As ZohoConfig = New ZohoConfig()
'        With conf
'            .ApiBaseUrl = ""
'            .OrganizationId = ""
'            .AuthToken = ""
'        End With

'        zohoClient = New ZohoClient(conf)

'    End Sub

'    Public Async Function CreateCustomer(Customer As ZsCustomerInput) As Task(Of ZsCustomer)
'        Return Await zohoClient.Subscription.Customers.CreateAsync(Customer)

'    End Function

'    Public Async Function CreateContact(CustomerID As String, Contact As ZsContactPersonInput) As Task(Of ZsContactPerson)
'        Return Await zohoClient.Subscription.ContactPersons.CreateAsync(CustomerID, Contact)

'        'ZohoClient.Subscription.Invoices
'    End Function

'    Sub MAIN()

'        Dim s As New send

'        Dim cust As New ZsCustomerInput
'        With cust
'            .CompanyName = ""
'            .CurrencyCode = ""
'            .Department = ""
'            .Designation = ""
'            .DisplayName = ""
'            .Email = ""
'            .Facebook = ""
'            .FirstName = ""
'            .LastName = ""
'            .Mobile = ""
'            .Notes = ""
'            .PaymentTerms = 1
'            .PaymentTermsLabel = ""
'            .Phone = ""
'            .Salutation = ""
'            .Skype = ""
'            .Twitter = ""
'            .Website = ""

'            With .ShippingAddress
'                .Attention = ""
'                .City = ""
'                .Country = ""
'                .Fax = ""
'                .State = ""
'                .Street = ""
'                .Zip = ""
'            End With

'            With .BillingAddress
'                .Attention = ""
'                .City = ""
'                .Country = ""
'                .Fax = ""
'                .State = ""
'                .Street = ""
'                .Zip = ""
'            End With

'        End With
'        Dim Customer As ZsCustomer = s.CreateCustomer(cust).Result

'        Dim Cont As New ZsContactPersonInput()
'        With Cont
'            .FirstName = ""
'            .LastName = ""
'            .Phone = ""
'            .Mobile = ""
'            .Email = ""
'        End With
'        Dim Contact As ZsContactPerson = s.CreateContact(Customer.CustomerId, Cont).Result


'    End Sub
'End Class
