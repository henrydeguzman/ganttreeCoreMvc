var gt = {
    init: function(){
        $(document).ready(this.ready);        
    },
    /**
     * toggle header
     */
    navToggle:function(self) {
        var $this= $(self), targetClass = $this.data('target'), target = $(targetClass);        
        target.is(':hidden') ? target.show() : target.hide();
    },
    /**
     * Sidebar-left function
     */
    sidebarLeft: function(self) {
        var $this = $(self),        
        value = $this.data('value'); // get the size of container to be set
        var sidebar = $('.gt-sidebar'), parent = sidebar.parent()
       
        content = $('.gt-content');
        console.log(value);
        if (parent.hasClass('sidebar-open')) {
            value = 0;
            parent.removeClass('sidebar-open');
        } else {
            parent.addClass('sidebar-open');
        }
        sidebar.css('width', value);
        content.css('margin-left', value);
    },
    /**
     * Sidebar-right function
     */
    sidebarRight: function(self){
        var $this = $(self), 
        targetElem = $this.data('target'),  // get the target element of container
        value = $this.data('value'); // get the size of container to be set
        var _class = $this.data('class');


        // set width of the container  
        var width = $(targetElem).css({
            width: value
        }); 
               
        console.log(width);
        if (_class === 'close' || value == 0) {
            $(targetElem).removeClass('open');
        } else {
            $(targetElem).addClass('open');            
        }        
     
       
    },
    ready:function () {
        console.log('document ready');
    }
};
gt.init();