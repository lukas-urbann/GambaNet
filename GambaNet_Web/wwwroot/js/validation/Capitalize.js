$.validator.addMethod('capitalize',
    function (value, element, params)
    {
        if (!value || value === '')
            return true;
        return Array.from(value)[0] >= 'A' && Array.from(value)[0] <= 'Z'
            || Array.from(value)[0] === 'Š' || Array.from(value)[0] === 'Č' || Array.from(value)[0] === 'Ř' || Array.from(value)[0] === 'Ž'
            || Array.from(value)[0] === 'Ý' || Array.from(value)[0] === 'Á' || Array.from(value)[0] === 'Í' || Array.from(value)[0] === 'É'
            || Array.from(value)[0] === 'Ú' || Array.from(value)[0] === 'Ď' || Array.from(value)[0] === 'Ň' || Array.from(value)[0] === 'Ó'
            || Array.from(value)[0] === 'Ť' || Array.from(value)[0] === 'Ě' || Array.from(value)[0] === 'Ů';
        
    });

$.validator.unobtrusive.adapters.add('capitalize', '',
    function (options)
    {
        var element = $(options.form).find('#Description')[0];
        options.rules['capitalize'] = [element, ''];
        options.messages['capitalize'] = options.message;
    });