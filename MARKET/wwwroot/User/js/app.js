(function($) {
    ////////////////owl-carousel one setup ////////////////////////
    $("#product-slider-one").owlCarousel({
        rtl: true,
        autoplay: true,
        loop: true,
        margin: 10,
        Touch: true,
        nav: true,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1.1,
                nav: true
            },
            560: {
                items: 2,
                nav: false
            },
            750: {
                items: 3,
                nav: false
            },
            1000: {
                items: 4,
                nav: true,
                loop: false
            },
            1350: {
                items: 5,
                nav: true,
                loop: false
            }
        }
    });
    ////////////////owl-carousel two setup ////////////////////////
    $("#product-slider-two").owlCarousel({
        rtl: true,
        autoplay: true,
        loop: true,
        margin: 10,
        Touch: true,
        nav: true,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1.1,
                nav: true
            },
            560: {
                items: 2,
                nav: false
            },
            750: {
                items: 1.2,
                nav: false
            },
            1000: {
                items: 3,
                nav: true,
                loop: false
            },
            1350: {
                items: 3,
                nav: true,
                loop: false
            }
        }
    });
    /*-------------------
    		Quantity change
    	--------------------- */
    var proQty = $('.pro-qty');
    proQty.prepend('<span class="dec qtybtn">-</span>');
    proQty.append('<span class="inc qtybtn">+</span>');
    proQty.on('click', '.qtybtn', function() {
        var $button = $(this);
        var oldValue = $button.parent().find('input').val();
        if ($button.hasClass('inc')) {
            var newVal = parseFloat(oldValue) + 1;
        } else {
            // Don't allow decrementing below zero
            if (oldValue > 0) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 0;
            }
        }
        $button.parent().find('input').val(newVal);
    });

    // PRICE SLIDER
    var slider = document.getElementById('price-slider');
    $("#price-slider");
    if (slider) {
        noUiSlider.create(slider, {
            start: [1000, 999000],
            connect: true,
            tooltips: [true, true],
            format: {
                to: function(value) {
                    return value.toFixed(0) + 'تومان';
                },
                from: function(value) {
                    return value
                }
            },
            range: {
                'min': 1000,
                'max': 999000
            }
        });
    }

    // sign in  and sign up 
    const sign_in_btn = document.querySelector("#sign-in-btn");
    const sign_up_btn = document.querySelector("#sign-up-btn");
    const container = document.querySelector(".register-container");
    sign_up_btn.addEventListener('click', () => {
        container.classList.add("sign-up-mode");
    });
    sign_in_btn.addEventListener('click', () => {
        container.classList.remove("sign-up-mode");
    });


})(jQuery);