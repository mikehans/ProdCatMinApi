# app-reg.sh
# Registers an application with Azure AD and creates a federated credential that will be used with GitHub Actions to create the infrastructure
# Pre-requisites: jq must be installed (apt install jq)


githubOrganizationName="mikehans"
githubRepositoryName="ProdCatMinApi"

federatedCredName="min-api-website-workflow"
repoBranchName="master"

azAppDisplayName="product-Catalogue-Minimal-Api"

appRegDetails=$(az ad app create --display-name $azAppDisplayName)
appRegObjId=$(echo $appRegDetails | jq -r '.id')
appRegAppId=$(echo $appRegDetails | jq -r '.appId')

az ad app federated-credential create \
    --id $appRegObjId  \
    --parameters  "{\"name\":\"${federatedCredName}\",\"issuer\":\"https://token.actions.githubusercontent.com\",\"subject\":\"repo:${githubOrganizationName}/${githubRepositoryName}:ref:refs/heads/${repoBranchName}\",\"audiences\":[\"api://AzureADTokenExchange\"]}"

az ad sp create --id $appRegObjId 


