# new-rg.sh
# Creates a new Azure resource group and role assignment using the Azure AD App Registration created with app-reg.sh
# Currently, I can't use the var $azAppDisplayName in the jq program as variable substitution can't be nested
#    and I can't figure out how to work with bash's constraints on this. I may need to use jq differently.
# Pre-requisites: jq must be installed (apt install jq)

rgResourceId=$(az group create --name product-catalogue-rg --query id --output tsv)
azAppDisplayName="product-Catalogue-Minimal-Api"

applist=$(az ad app list)
appRegAppId=$(echo $applist | jq '.[] | select(.displayName="product-Catalogue-Minimal-Api"')

az role assignment create --assignee $appRegAppId --role Contributor --scope $rgResourceId 

echo "AZURE_CLIENT_ID: $appRegAppId"
echo "AZURE_TENANT_ID: $(az account show --query tenantId --output tsv)"
echo "AZURE_SUBSCRIPTION_ID: $(az account show --query id --output tsv)"
