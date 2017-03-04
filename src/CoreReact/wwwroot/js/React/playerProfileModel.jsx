
//Example: /<PlayerStat  name="Russell Wesbrook />
// script must be at the bottom so that it can render from elements still existing in the DOM before the script becomes the head and there is no more "document".
//IN REACT,FUNCTION CALLS MUST BE DONE WITHIN THE "{}" BRACKETS
function getStateFromDotNetModel(data) {
    try {
        return data;
    } catch (e) {
        throw new Error("ERROR: Could not Retrieve Model JSON from .Net Server");
    }
}

function getImmutableClone(object, property, val) {
    const objectClone = Object.assign({}, object);
    if (typeof(property) != "string") {
        throw new Error("Error: object not changed because 'property' wasn't a string");
    }
    if (typeof(val) !== typeof(objectClone[property])) {
        throw new Error("Error: 'val' must be of type: " + typeof(objectClone[property]));
    } else {
        objectClone[property] = val;
    }
    return objectClone;
}

function fadeInByID(id) {
    var $id = $("id");
    $id.fadeIn(500,function() {
        console.log("element of ID: "+ id + " faded in if hidden...");
    });
}
class PlayerStat extends React.Component {
    render() {
        this.categoryBlockID = "category" + this.props.category;
        return (
            <div id={this.categoryBlockID}>1
                <div className="playerCategory">{this.props.category}</div>
                <div className="playerCategoryValue" style={this.props.playerStatStyle}>{this.props.categoryValue}</div>
            </div>);
    }
}

class PlayerProfile extends React.Component {
    constructor() {
        super();
        const numCategories = 13;
        this.state = {
            sampleData: getStateFromDotNetModel(data),
            playerStatStyle: {
                opacity: 0.0
            }
        }
    }
    handleShowAllClick() {
        //create clone of player style to preserve immutability
        const newPlayerStatStyle = getImmutableClone(this.state.playerStatStyle, "opacity", 1.0);
        this.setState(
        {
            playerStatStyle: newPlayerStatStyle
        });
    }
    isFilteredNamingCategory(category) {
        if (category.toString() === "Id" || category.toString() === "FirstName" || category.toString() === "LastName") {
            return true;
        } else {
            return false;
        }
    }
    renderPlayerStatList() {
        const categories = Object.keys(this.state.sampleData);
        var categoriesFiltered = categories.filter((category) =>!this.isFilteredNamingCategory(category));
        var categoriesMapped = categoriesFiltered.map((category) =>
         <li id={"statList"+category.toString()} key={category.toString() }>
            <PlayerStat categoryValue={this.state.sampleData[category]} category={category} playerStatStyle={this.state.playerStatStyle}></PlayerStat>
         </li>);
        return categoriesMapped;

    }
    render() {
        return (
            <div className="playerProfile">
            <button onClick={() =>this.handleShowAllClick()}>Show All</button>
            <ul>
                {this.renderPlayerStatList()}
            </ul>
            </div>
    );
    }
}


ReactDOM.render(
    <PlayerProfile />,
    document.getElementById('playerReactComp')
    );
