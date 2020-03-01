
# Sitecore Marketplace Module
Sitecore Marketplace Module with in Sitecore enables the Sitecore Developers to explore plug and play modules available on Marketplace.
Developer can see the Most Recommended, Top Downloaded Sitecore modules and search through marketplace for more. Also, there is a flexibility to install a package with single click.

# Idea
The main idea behind this module is to improve the developers engagement with Sitecore marketplace. So that they wont re-invent the wheel.
At present, this is just an idea which showcase the capability we can get with a mix of Sitecore Speak Application and Sitecore Marketplace.

## Getting Started
### Prerequisites

 - Basic knowledge of Sitecore
 - Sitecore 9.3
 - Change in web.config 
 ```
 Go to web.config and change the below setting 

From:
<add name="Content-Security-Policy" value="default-src 'self' 'unsafe-inline' 'unsafe-eval' https://apps.sitecore.net; img-src 'self' data:; style-src 'self' 'unsafe-inline' https://fonts.googleapis.com; font-src 'self' 'unsafe-inline' https://fonts.gstatic.com; upgrade-insecure-requests; block-all-mixed-content;" />

To:
<add name="Content-Security-Policy" value="default-src 'self' 'unsafe-inline' 'unsafe-eval' https://apps.sitecore.net; img-src 'self' 'unsafe-inline' https://marketplace.sitecore.net data:; style-src 'self' 'unsafe-inline' https://fonts.googleapis.com; font-src 'self' 'unsafe-inline' https://fonts.gstatic.com; upgrade-insecure-requests; block-all-mixed-content;" />

Reason for change is that Speak applicaiton won't allow interaction to 3rd party until it accept that particular origin.
```

### Installing

For installing the module following steps are required to be followed

 1. Go to the [Sitecore Marketplace Package](https://github.com/Sitecore-Hackathon/rogueCoders/blob/master/sc.package/SitecoreMarketPlace.zip) and clone it.
 2. Install the Package using Sitecore Package Installation Wizard.
 3. Restart the Sitecore Client.

## Mocked
Currently, Sitecore APIs for the marketplace are not available, so we have mocked them. We have used the hard-coded package Publish Viewer to demonstrate the package installation using our module.

## Deployment

This is not a product ready module as mentioned earlier. It demonstrate the idea of integrating Sitecore Marketplace within Sitecore and encouraging Sitecore developers to use ready-made Sitecore modules.

## Versioning

This is the initial prototype version.

## Authors

* **Chirag Khanna** - [LinkedIn](https://www.linkedin.com/in/chirag-khanna-44861087)
* **Gaurav Arora** - [LinkedIn](https://www.linkedin.com/in/arora-gaurav)
* **Sachin Kumar Dabas** - [LinkedIn](https://www.linkedin.com/in/sachin-dabas)

## References
### Screenshots
![Screenshot1](https://photos.google.com/album/AF1QipO3Xl8alBGNMzLtp_Xni4GiDOxyJjn8S73lbfWx/photo/AF1QipOHVhGhkt19x29fE3RuCahRjLJD-LcCpoL0m7uM)
### Video
Check out our module in action on [Youtube](https://youtu.be/ctvGirA4EIk)
## License

This project was implemented using the Sitecore Developers License.