define(["sitecore"], function (Sitecore) {
  var SearchResultsPageCode = Sitecore.Definitions.App.extend({
    initialized: function () {
      },
      getSearchItems: function () {

          var searchText = this.SearchButton.attributes.text;

          $.ajax({
              method: "GET",
              url: "/api/sitecore/MarketPlaceAPI/GetSearchItem?searchText=" + searchText
          }).done(function (response) {

              var html = "";
              var result = JSON.parse(response);

              for (var count = 0; count < result.more.items.length; count++) {
                  var item = result.more.items[count];
                  html += "<li><img class='rec-module-img' src= '" + item.moduleimg + "'>" + "<div class='module review'><div class='module-review-section'><span class='rec-module-heading'>" + item.modulename + "</span><div class='review-section'><span class='review-section-container'>";

                  var no_stars = 5 - Math.ceil(item.rate);
                  for (var reviewcount = 0; reviewcount < Math.ceil(item.rate); reviewcount++) {
                      html += "<img src='/sitecore/shell/client/YourApps/SitecoreMarketPlace/Images/star_checked.png'/>";
                  }

                  for (var nostarcount = 0; nostarcount < no_stars; nostarcount++) {
                      html += "<img src='/sitecore/shell/client/YourApps/SitecoreMarketPlace/Images/star_unchecked.png'/>";
                  }

                  html += "</span><span class='like-container'><span class='like'>" + item.like + "</span><span class='reviews'>" + item.reviews + "</span></span><div class='install-package'><span>Install Package</span></div></div></div></div></li>";
              }
              $(".search-result-list").html(html);
          });
      }
  });

  return SearchResultsPageCode;
});