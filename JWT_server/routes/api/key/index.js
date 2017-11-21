const router = require('express').Router()
const controller = require('./key.controller')
const authMiddleware = require('../../../middlewares/auth')

router.use('/sendKey', authMiddleware)
router.use('/validateKey', authMiddleware)
router.use('/getKey', authMiddleware)

router.post('/sendKey', controller.sendKey)
router.post('/validateKey', controller.validateKey)
router.post('/getKey',controller.getKey)

module.exports = router