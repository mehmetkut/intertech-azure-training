## Overview

<a href="https://www.visualstudio.com/en-us/docs/release/overview/">Release Management</a> is a service in Visual Studio Team Services that helps you automate the deployment and testing of your software in multiple environments. Using Release Management, you can either fully automate the delivery of your software all the way to production, or set up semi-automated processes with approvals and on-demand deployments. It is an essential element of DevOps that helps your team continuously deliver software to your customers at a faster pace and with lower risk.

Release Management can be used by all kinds of software developers for continuous automated deployment, or by large enterprises to improve efficiency and collaboration between various teams that participate in release processes.

To use Release Management, you create release definitions, in which you specify the automation tasks that should be run in each environment. These automation tasks can be to deploy your software and to run tests against it. You can group multiple environments in each definition to model your software lifecycle. You can then set up the deployment in each environment to be automatically triggered upon completion of a build, at scheduled times, or on successful deployment to a previous environment.

## Pre-requisites

In order to complete this lab you will need- 

- **Visual Studio Team Services account**. If you don't have one, you can create from <a href="https://www.visualstudio.com/">here</a>

- **Visual Studio 2017** or higher version

- You can use the **[VSTS Demo Data generator](http://vstsdemogenerator.azurewebsites.net/Environment/Create)** to provison a project with pre-defined data on to your Visual Studio Team Services account. Please use the ***My Health Clinic*** template to follow the hands-on-labs.

- If you are not using the VSTS Demo Data Generator, you can clone the code from here

## Exercise 1: Connect To Microsoft Azure

1.  Sign in to your Visual Studio Team Services account. 

2.	From your account overview page, select your team project. To find your team project, use can search as well.

    <img src="images/1.png" width="624"/> 

3.	Choose the **gear icon** to open the administrative control panel.

    <img src="images/2.png" width="624"/> 

4.	Go to **Services** and click on **New Service Endpoint** to add one.

    <img src="images/3.png" width="624"/> 

5.	From the drop down, select **Azure Resource Manager**.

    <img src="images/4.png" />

6.	Provide a Connection name **MHC-Azure** and select the subscription.

    <img src="images/5.png" />

## Exercise 2: Creating Release Definitions

1. Go to your **Release** tab from your VSTS account.

    <img src="images/7.png" width="624"/>

2. Click on **+** to create a new release definition.

    <img src="images/8.png" />

3. In the Create new release definition dialog, select the **Azure App Service Deployment** template and choose **Next.**

    <img src="images/9.png" />

4. In the next page, select the **build definition** you created earlier and choose **Create.** 

    <img src="images/10.png" />

5. This creates a new release definition with one default environment. Rename the Environment to **Dev**.

    <img src="images/11.png" width="624"/>

6. In the **Azure Subscription**, map the endpoint which we created in **Exercise 1**.

    <img src="images/12.png" width="624"/>

7. If you would have hosted the WebApp on Azure, you will get an App Service which has to be mapped in your release definition. If you haven't published on Azure, you can follow this <a href="https://almvm.azurewebsites.net/labs/vsts/appservice/"/>post</a> to host.

    <img src="images/13.png" width="624"/>

8. Select the **MyHealth.Web.zip** file to deploy.

    <img src="images/14.png" width="624"/>

9. We will replace the database connection string in the **appsettings.json** to point to a database server on Azure.

   <img src="images/48.png" />

10. Go to **Variables** tab and create a variable with the below name and value.

    >Note:  You will need to create a SQL database server on Azure prior to this step. If you have an existing SQL Server on Azure, you can use it, Otherwise follow this <a href="http://bit.ly/2o2IDTy" >blog post</a>for step-by-step intsructions.

    >Name: ConnectionStrings.DefaultConnection

    >Value: Server=tcp:{yourdbserver},1433;Database=myhealthclinic;User ID={dbuserid};Password={dbpassword};Trusted_Connection=False;Encrypt=True;

9. Give a name for the new release definition and Save the release definition.

10. Create a **new release** and select the **latest** build to deploy it to the single environment in the definition.

    <img src="images/15.png" width="624"/>

    <img src="images/16.png" width="624"/>

11. Go to the release definition log to view the process.

    <img src="images/17.png" />

    <img src="images/18.png" />

12. You can go to the Azure Portal and get the existing Web App Service URI.

    <img src="images/19.png" width="624"/>

13. Click on **Private area** to login.
    - Username: User
    - Password: P2ssw0rd@1

    <img src="images/20.png" width="624"/>

    <img src="images/21.png" />

14. Once logged in, you should see this dashboard.

    <img src="images/22.png" width="624"/>

## Exercise 3: Manage Releases

### Task 1: Triggers

1. A Release definition can be configured to automatically create a new release when it detects new artifacts are available.
   Typically as a result of a new build of the application. Click on **Triggers** from your release definition as shown.

   <img src="images/23.png" width="624"/>

   > - **Manual:** No releases are initiated automatically when a new build of the source artifacts occurs. All releases for this release definition must be created manually by choosing the Release icon in a release definition or from a build summary. 

   > - **Continuous Deployment:** A new release is created automatically when Release Management detects new built artifacts are available. When you select this option, a drop-down list enables you to select which of the artifact sources linked to this release definition will trigger a new release.

   > - **Scheduled:** A new release is created based on a schedule you specify. When you select this option, a set of controls enables you to select the days of the week and the time of day that Release Management will automatically create a new release.

   > **NOTE:** However, even though a release is automatically created, it might not be deployed automatically to an environment. To enable automatic deployment, you must also configure environment deployment triggers in each environment for which you want automated deployments to occur. The lower section of the Triggers tab lists the environments configured for this release definition.

2. Click on **Continuous Deployment** to create a new release automatically.

   <img src="images/24.png" width="624"/>

3. Click on the **...** button on the environment and select **Deployment Conditions**.

    > The deployment conditions dialog for the environment shows the currently configured environment deployment triggers and deployment queuing policies. Users with permission to edit release definitions can edit the deployment conditions here, including environment deployment triggers and deployment queuing policies.

   <img src="images/25.png" width="624"/>
