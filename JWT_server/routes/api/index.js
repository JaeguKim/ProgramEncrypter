const router = require('express').Router()
const auth = require('./auth')
const key = require('./key')
const user = require('../../models/user')

router.use('/',key)
router.use('/auth', auth)

module.exports = router