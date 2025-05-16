# task-management-system
To deploy in azure using azure cli
Steps: 
    1. az login
    2. az group create -n <groupname> --location eastus
    3. dotnet publish -c Release -r win-x86 --self-contained true -o ./publish
    4. Compress-Archive -Path .\publish\* -DestinationPath publish.zip
    3. az webapp create -g <groupname> -n <appservicename> --sku F1 --os-type window
    4. az webapp deploy --resource-group <groupname> --name <appservicename> --src-path ./publish.zip