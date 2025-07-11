@allowed([
  'nonprod'
  'prod'
])
param environmentType string

var appServicePlanTierName = (environmentType == 'prod') ? 'S1' : 'F1'

@description('Or, I can get the location of the current resource group and use that location - makes sense really')
param rgloc string = resourceGroup().location

@description('App Service Plan name')
param appServicePlanName string = 'prodcatplan0'

var uniqueAppServcePlanName = '${appServicePlanName}${uniqueString(resourceGroup().id)}'

@description('App Service App name')
param appServiceApp string = 'prodcatapp0'

@description('App Service runtime')
param appServiceRuntime string = 'DOTNETCORE:8.0' 

var uniqueAppServiceApp = '${appServiceApp}${uniqueString(resourceGroup().id)}'

var appServicePlanString = length(uniqueAppServcePlanName) > 24
  ? substring(uniqueAppServcePlanName, 0, 24)
  : uniqueAppServcePlanName
var appServiceAppString = length(uniqueAppServiceApp) > 24 ? substring(uniqueAppServiceApp, 0, 24) : uniqueAppServiceApp

resource appServicePlan 'Microsoft.Web/serverfarms@2024-11-01' = {
  name: appServicePlanString
  location: rgloc
  sku: {
    name: appServicePlanTierName
  }
  kind: 'linux'
}

resource apiWebApp 'Microsoft.Web/sites@2024-11-01' = {
  name: appServiceAppString
  location: rgloc
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
    siteConfig:{
        linuxFxVersion: appServiceRuntime
    }
  }
}
