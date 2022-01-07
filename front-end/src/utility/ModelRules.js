const ModelRules = {
    required: value => !!value || 'Zorunlu alan.',
    min: v => v.length > 0 || 'En az üç karakter',
    rOn: v => v.length == 10 || '10 karakter girilmelidir.',
    rOnbir: v => v.length == 11 || '11 karakter girilmelidir.',
    email: v => /.+@.+\..+/.test(v) || 'E-mail geçersiz',
}

export default ModelRules