# CheckList
Bu uygulama zincir mağazalara sahip işletmelerin rutin işlemlerinin kontrolu için Keleşler Yazılım tarafından geliştirilmiştir.

## Database Migration

Migration işlemini gerçekleştirmeden önce SQL Server'a bağlanmak için connection string bilgisinin makinaya göre ayarlamanız gerekmektedir. 
Bunun için CheckList.Api.Configuration namespace altındaki appsettings.development.json dosyasındaki bağlantı düzeltilmelidir.

Bu işlemden sonra Powershell veya Command Promt üzerinden aşağıdaki adımların takip edilmesi gerekmektedir.

```
> set KELESLER_CHECKLIST_ENVIRONMENT=development
> set KELESLER_CHECKLIST_ENVIRONMENT=test
> dotnet ef migrations add initialize
> dotnet ef database update
```
