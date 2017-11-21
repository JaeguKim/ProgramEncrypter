const jwt = require('jsonwebtoken')
var NodeRSA = require('node-rsa');

var decrypt_key = new NodeRSA({b: 512});

decrypt_key.importKey({
    n: new Buffer('0086fa9ba066685845fc03833a9699c8baefb53cfbf19052a7f10f1eaa30488cec1ceb752bdff2df9fad6c64b3498956e7dbab4035b4823c99a44cc57088a23783', 'hex'),
    e: 65537,
    d: new Buffer('5d2f0dd982596ef781affb1cab73a77c46985c6da2aafc252cea3f4546e80f40c0e247d7d9467750ea1321cc5aa638871b3ed96d19dcc124916b0bcb296f35e1', 'hex'),
    p: new Buffer('00c59419db615e56b9805cc45673a32d278917534804171edcf925ab1df203927f', 'hex'),
    q: new Buffer('00aee3f86b66087abc069b8b1736e38ad6af624f7ea80e70b95f4ff2bf77cd90fd', 'hex'),
    dmp1: new Buffer('008112f5a969fcb56f4e3a4c51a60dcdebec157ee4a7376b843487b53844e8ac85', 'hex'),
    dmq1: new Buffer('1a7370470e0f8a4095df40922a430fe498720e03e1f70d257c3ce34202249d21', 'hex'),
    coeff: new Buffer('00b399675e5e81506b729a777cc03026f0b2119853dfc5eb124610c0ab82999e45', 'hex')
}, 'components');

const authMiddleware = (req, res, next) => {
    // read the token from header or url 
    const token = req.headers['x-access-token'] || req.query.token

    // token does not exist
    if(!token) {
        return res.status(403).json({
            success: false,
            message: 'not logged in'
        })
    }

    // create a promise that decodes the token
    const p = new Promise(
        (resolve, reject) => {
            console.log('encryted token : '+token);
            const decrypted_token = decrypt_key.decrypt(token,'utf-8');
            console.log('decrypted token : '+decrypted_token);
            jwt.verify(decrypted_token, req.app.get('jwt-secret'), (err, decoded) => {
                if(err) reject(err)
                resolve(decoded)
            })
        }
    )

    // if it has failed to verify, it will return an error message
    const onError = (error) => {
        res.status(403).json({
            success: false,
            message: error.message
        })
    }

    // process the promise
    p.then((decoded)=>{
        req.decoded = decoded
        next()
    }).catch(onError)
}

module.exports = authMiddleware