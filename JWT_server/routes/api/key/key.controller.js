const User = require('../../../models/user')

var NodeRSA = require('node-rsa');

var encrypt_key = new NodeRSA({b: 512});

encrypt_key.importKey({
    n: new Buffer('0086fa9ba066685845fc03833a9699c8baefb53cfbf19052a7f10f1eaa30488cec1ceb752bdff2df9fad6c64b3498956e7dbab4035b4823c99a44cc57088a23783', 'hex'),
    e: 65537,
    d: new Buffer('5d2f0dd982596ef781affb1cab73a77c46985c6da2aafc252cea3f4546e80f40c0e247d7d9467750ea1321cc5aa638871b3ed96d19dcc124916b0bcb296f35e1', 'hex'),
    p: new Buffer('00c59419db615e56b9805cc45673a32d278917534804171edcf925ab1df203927f', 'hex'),
    q: new Buffer('00aee3f86b66087abc069b8b1736e38ad6af624f7ea80e70b95f4ff2bf77cd90fd', 'hex'),
    dmp1: new Buffer('008112f5a969fcb56f4e3a4c51a60dcdebec157ee4a7376b843487b53844e8ac85', 'hex'),
    dmq1: new Buffer('1a7370470e0f8a4095df40922a430fe498720e03e1f70d257c3ce34202249d21', 'hex'),
    coeff: new Buffer('00b399675e5e81506b729a777cc03026f0b2119853dfc5eb124610c0ab82999e45', 'hex')
}, 'components');

/*
    POST /api/sendKey
    {
        username,
        encrypted_key
    }
*/
exports.sendKey = (req, res) => {
    const { username, encrypted_key } = req.body
    let updateUser = null
    // store key if user exists
    const store = (user) => {
        if(user) {
            updateUser = user;
            return updateUser.storeKey(encrypted_key)
        } else {
            throw new Error('username not exists')
        }
    }

    // respond to the client
    const respond = () => {
        res.json({
            message: 'key sending success'
        })
    }

    // run when there is an error (username not exists)
    const onError = (error) => {
        res.status(409).json({
            message: error.message
        })
    }

    // check username duplication
    User.findOneByUsername(username)
    .then(store)
    .then(respond)
    .catch(onError)
}

/*
    POST /api/validateKey
    {
        username,
        encrypted_key
    }
*/
exports.validateKey = (req, res) => {
    const { username, encrypted_key } = req.body
    
    //verify key if user exists
    const validateKey = (user) => {
        if(!user) {
            // user does not exist
            throw new Error('user not exists')
        } else {
            // user exists, verify key
            if(!user.validateKey(encrypted_key)) {
                throw new Error('validation failed') 
            }
        }
    }

    // respond the token 
    const respond = () => {
        res.json({
            message: 'key validation success',
        })
    }

    // error occured
    const onError = (error) => {
        res.status(403).json({
            message: error.message
        })
    }

    // find the user
    User.findOneByUsername(username)
    .then(validateKey)
    .then(respond)
    .catch(onError)
}

/*
    POST /api/getKey
    {
        username
    }
*/

exports.getKey = (req, res) => {
    const { username } = req.body
    let encrypted_key = null

    // get key if user exists
    const getKey = (user) => {
        if(user) {
            return user.key
        } else {
            throw new Error('username not exists')
        }
    }
    
    // respond to the client
    const respond = (key_val) => {
        console.log('before encrypted : '+key_val);
        encrypted_key = encrypt_key.encrypt(key_val,'base64');
        console.log('encrypted key : '+encrypted_key);
        res.json({
            encrypted_key: encrypted_key
        })
    }

    // run when there is an error (username not exists)
    const onError = (error) => {
        res.status(409).json({
            message: error.message
        })
    }

    // check username duplication
    User.findOneByUsername(username)
    .then(getKey)
    .then(respond)
    .catch(onError)
}