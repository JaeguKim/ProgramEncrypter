const router = require('express').Router()
const controller = require('./key.controller')

router.post('/sendKey', controller.sendKey)
router.post('/validateKey', controller.validateKey)
router.post('/getKey',controller.getKey)

module.exports = router