define(
    [
        "knockout",
        "sitecore",
        "/-/speak/v1/ExperienceEditor/ExperienceEditor.js",
        "/-/speak/v1/ExperienceEditor/LeftOverflowPanel.js",
        "jquery",
        "jqueryui",
        "/sitecore/shell/client/Speak/Assets/lib/ui/1.1/deps/knockout-sortable/knockout-sortable.js"

    ],
    function (ko, Sitecore, ExperienceEditor, LeftOverflowPanel) {
        Sitecore.Factories.createBaseComponent({
            name: "RenderingList",
            base: "ControlBase",
            selector: ".sc-MostRecommended",
            events:
            {
               

            },
            initialize: function () {

                var moduleheading = this.$el[0].attributes["data-sc-module-heading"].value;
                this.model.set("moduleheading", moduleheading);

                $.ajax({
                    method: "GET",
                    url: "/api/sitecore/MarketPlaceAPI/GetRecommendedItems"
                }).done(function (response) {
                    
                    var html = "";
                    var result = JSON.parse(response);
                    console.log(result);
                        for (var count = 0; count < result.more.items.length; count++) {
                            var item = result.more.items[count];
                            html += "<li><img class='rec-module-img' src= '" + item.moduleimg + "'>" + "<div class='module review'><div class='module-review-section'><span class='rec-module-heading'>" + item.modulename + "</span><div class='review-section'><span class='review-section-container'>";

                            var no_stars = 5 - Math.ceil(item.rate);
                            for (var reviewcount = 0; reviewcount < Math.ceil(item.rate); reviewcount++){
                                html += "<img src='/sitecore/shell/client/YourApps/SitecoreMarketPlace/Images/star_checked.png'/>";
                            }

                            for (var nostarcount = 0; nostarcount < no_stars; nostarcount++) {
                                html += "<img src='/sitecore/shell/client/YourApps/SitecoreMarketPlace/Images/star_unchecked.png'/>";
                            }

                            html += "</span><span class='like-container'><span class='like'>" + item.like + "</span><span class='reviews'>" + item.reviews + "</span></span><div class='install-package' data-attr-package-url='" + item.packageLink + "'><span>Install Package</span></div><div class='processingbar'></div></div></div></div></li>";
                        }
                        $(".recommended-list").append(html);
                    
                    })

                var success = 0;
                $("body").on('click', '.install-package', function () {
                    var elem = $(this);
                    var processBar = $(this).next('.processingbar');
                    processBar.progressbar({
                        value: 0
                    });
                    var packageurl = $(this).attr('data-attr-package-url');
                    move(processBar);
                    $.ajax({
                        method: "POST",
                        url: "/api/sitecore/MarketPlaceAPI/InstallPackage",
                        data: { "url": packageurl }
                    }).done(function (response) {
                        var html = "";
                        $(elem).css("width", '100%');
                        success = 1;
                    })
                });
                function move(element) {
                    var id = setInterval(function () {
                        var currVal = element.attr("aria-valuenow");
                        var maxVal = element.attr("aria-valuemax");
                        if (parseInt(currVal) < parseInt(maxVal)) {
                            element.progressbar({
                                value: parseInt(currVal) + 10
                            });
                        }
                        else {
                            element.progressbar({
                                disabled: true
                            });
                            clearInterval(id);
                        }
                    }, 500);
                }


   


               
            }
        })
    
})