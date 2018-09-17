
$(document).ready(function(){
	/* === Icon Hamburger === */
	$('.hamburger-icon').click(function(){
		$(this).toggleClass('open');
		$('.menu-collapse').slideToggle();
	});

	/* === Dropdown-link === */
	$('.navbar-link_toggle').click(function(){
		$('.collapse-link').fadeToggle();
	});

	/* === Slider === */
	$('.slider').slick({
		arrows: false,
		dots: true,
		autoplay: true,
		autoplaySpeed: 3500,
		infinite: true,

		/* Fade */
		speed: 900,
		fade: true,
		cssEase: 'cubic-bezier(0.7, 0, 0.3, 1)',
		draggable: true,
	    touchThreshold: 100
    });

	/* === Accordion === */
	$('.dropdown-toggle').click(function(e) {
		e.preventDefault();

		var $this = $(this);

		if ($this.next().hasClass('show')) {
			$this.next().removeClass('show');
			$this.next().fadeOut();
		} else {
			$this.parent().parent().find('.collapse').removeClass('show');
			$this.parent().parent().find('.collapse').fadeOut();
			$this.next().toggleClass('show');
			$this.next().fadeToggle();
		}
	});

	// Menu Full Screen
    $('#toggle').click(function() {
        $(this).toggleClass('active');
        $('#overlay-header').toggleClass('open');
    });

	/* === FancyBox Iframe === */
	$("[data-fancybox-iframe]").fancybox({
		// Options will go here
		toolbar  : false,
		smallBtn : true,
		iframe : {
			preload : false
		}
	});

	/* === FancyBox Galería === */
	$("[data-fancybox-gallery]").fancybox({
		// Options will go here
		loop: true,
		animationEffect: "zoom-in-out",
		buttons: [
	        //'slideShow',
	        'fullScreen',
	        'thumbs',
	        //'download',
	        //'share',
	        'close'
	    ]
	});

	/* === FancyBox Videos === */
	$("[data-fancybox-video]").fancybox({
		// Options will go here
		buttons: [
	        //'slideShow',
	        //'fullScreen',
	        'thumbs',
	        //'download',
	        //'share',
	        'close'
	    ]
		/*
		youtube : {
	        controls : 0,
	        showinfo : 0
	    }
		*/
	});

});
